using RavencoinLib.CoinParameters.Base;

namespace RavencoinLib.CoinParameters.Ravencoin
{
    public static class RavencoinConstants
  {
        public sealed class Constants : CoinConstants<Constants>
        {
            public readonly ushort CoinReleaseHalfsEveryXInYears = 4;
            public readonly ushort DifficultyIncreasesEveryXInBlocks = 2016;
            public readonly uint OneRavenInRaventoshis = 100000000;
            public readonly decimal OneRaventoshisInRaven = 0.00000001M;
            public readonly decimal OneMicroravenInRaven = 0.000001M;
            public readonly decimal OneMilliravenInRaven = 0.001M;
            public readonly string Symbol = "RVN";
        }
    }
}