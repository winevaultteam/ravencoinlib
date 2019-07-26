
namespace RavencoinLib.Responses
{
    public class GetAssetDataResponse
    {
        public string Name { get; set; }
        public double Amount {get; set;}
        public int Units { get; set; }
        public int Reissuable {get; set;}
        public int HasIpfs { get; set; }
        public string IpfsHash {get; set;}
    }
}