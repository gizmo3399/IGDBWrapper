namespace IgdbWrapper.Api.Enums
{
    /// <summary>
    /// Enumeration that indicates the status of a game.
    /// </summary>
    public enum GameStatus
    {
        /// <summary>
        /// The game has been released to the public.
        /// </summary>
        Released = 0,

        /// <summary>
        /// The game is currently in an alpha phase.
        /// </summary>
        Alpha = 2,

        /// <summary>
        /// The game is currently in a beta phase.
        /// </summary>
        Beta = 3,

        /// <summary>
        /// The game is available through early access.
        /// </summary>
        EarlyAccess = 4,

        /// <summary>
        /// The game is off-line for the moment.
        /// </summary>
        Offline = 5,

        /// <summary>
        /// The game's development has been canceled.
        /// </summary>
        Canceled = 6
    }
}