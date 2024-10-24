namespace GameApi;

[Flags]
public enum LocationTag
{
    None = 1,
    Inside = 2,
    Outside = 4,
    WestCampus = 8,
    MainCampus = 16,
    NorthCampus = 32,
    OffCampus = 64,
    AcademicBuilding = 128,
    ResidenceHall = 256,
    MiscellaniousBuilding = 512,
    CampusExtension = 1024,
}
