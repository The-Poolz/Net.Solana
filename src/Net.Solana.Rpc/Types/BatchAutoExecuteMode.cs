﻿namespace Net.Solana.Rpc.Types;

/// <summary>
/// Represents the different auto execute modes for an `SolanaRpcBatchComposer`
/// </summary>
public enum BatchAutoExecuteMode
{  
    /// <summary>
    /// No auto execution.
    /// </summary>
    Manual = 0,

    /// <summary>
    /// Execute with RPC batch failure throwing an Exception.
    /// </summary>
    ExecuteWithFatalFailure = 1,

    /// <summary>
    /// Execute with RPC batch failures execptions routed into callbacks.
    /// </summary>
    ExecuteWithCallbackFailures = 2
}