namespace IgdbWrapper.Api.Enums
{
    /// <summary>
    /// Enumeration that indicates what kind of category a game is in.
    /// </summary>
    public enum GameCategory
    {
        /// <summary>
        /// This is the main game itself.
        /// </summary>
        MainGame = 0,

        /// <summary>
        /// This is a DLC or add-on for another game.
        /// </summary>
        Dlc = 1,

        /// <summary>
        /// This is an expansion for another game.
        /// </summary>
        Expansion = 2,

        /// <summary>
        /// This is a bundle consisting of multiple games.
        /// </summary>
        Bundle = 3,

        /// <summary>
        /// This is a stand-alone expansion for another game.
        /// </summary>
        StandAloneExpansion = 4
    }
}