using System.Timers;
using Timer = System.Timers.Timer;

namespace Net.Solana.Rpc.Types;

public class ConnectionStats : IConnectionStatistics
{
    private readonly Timer _timer;

    private readonly Dictionary<long, ulong> _historicData;

    public ulong TotalReceivedBytes { get; set; }

    public ulong AverageThroughput10Seconds { get; set; }

    public ulong AverageThroughput60Seconds { get; set; }


    public void AddReceived(uint count)
    {
        TotalReceivedBytes += count;
        var secs = (long)(DateTime.UtcNow - DateTime.UnixEpoch).TotalSeconds;

        lock (this)
        {
            if (!_timer.Enabled)
                _timer.Start();

            if (_historicData.TryGetValue(secs, out var current))
            {
                _historicData[secs] = current + count;
            }
            else
            {
                _historicData[secs] = count;
            }

            AverageThroughput60Seconds += count / 60;
            AverageThroughput10Seconds += count / 10;
        }
    }

    public ConnectionStats()
    {
        _timer = new Timer(1000)
        {
            AutoReset = true
        };
        _timer.Elapsed += RemoveOutdatedData;
        _historicData = new Dictionary<long, ulong>();
    }

    private void RemoveOutdatedData(object? sender, ElapsedEventArgs e)
    {
        var currentSec = (long)(DateTime.UtcNow - DateTime.UnixEpoch).TotalSeconds;

        lock (this)
        {
            if (_historicData.ContainsKey(currentSec - 60))
            {
                _historicData.Remove(currentSec - 60);
            }
            if (_historicData.Count == 0)
            {
                _timer.Stop();
                AverageThroughput60Seconds = 0;
                AverageThroughput10Seconds = 0;
            }
            else
            {
                ulong total = 0, tenSecTotal = 0;
                foreach (var kvp in _historicData)
                {
                    total += kvp.Value;
                    if (kvp.Key > currentSec - 10)
                    {
                        tenSecTotal += kvp.Value;
                    }
                }
                AverageThroughput60Seconds = total / 60;
                AverageThroughput10Seconds = tenSecTotal / 10;
            }
        }
    }
}