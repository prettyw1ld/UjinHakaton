namespace UjinTemplateServer.Common
{
    public class UjinBuildingsResponse
    {
        public UjinBuildingsData Data { get; set; } = null!;
    }

    public class UjinBuildingsData
    {
        public List<UjinBuildingItem> Buildings { get; set; } = [];
    }

    public class UjinBuildingItem
    {
        public UjinComplex Complex { get; set; } = null!;
        public UjinBuilding Building { get; set; } = null!;
    }

    public class UjinComplex
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
    }

    public class UjinBuilding
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;

        public UjinAddress Address { get; set; } = null!;
    }

    public class UjinAddress
    {
        public string FullAddress { get; set; } = string.Empty;
    }
}
