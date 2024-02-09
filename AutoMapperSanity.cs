using AutoMapper;

namespace NestedIdMapping.Tests;

public class AutoMapperSanity
{
    [Fact]
    public void Work()
    {
        var mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(new MyProfile())));
        var expectedGuidText = Guid.NewGuid().ToString();
        var dest = mapper.Map<ChildDto>(new Aggregate(new Child { ChildId = expectedGuidText, Name = "name" }));
        Assert.Equal("name", dest.Name);
        Assert.Equal(expectedGuidText, dest.ChildId);
    }

}
public class MyProfile : Profile
{
    public MyProfile()
    {
        CreateMap<Aggregate, ChildDto>()
            .ConstructUsing(src => new ChildDto(src.Child.ChildId ?? string.Empty, src.Child.Name ?? string.Empty));
    }
}

public class Child
{
    public Guid Id { get; set; }
    public string? ChildId { get; set; }
    public string? Name { get; set; }
}

public class Aggregate
{
    public Aggregate(Child child)
    {
        Child = child;
    }

    public Child Child { get; set; }
}

public class ChildDto
{
    public ChildDto(string childId, string name)
    {
        ChildId = childId;
        Name = name;
    }

    public string ChildId { get; set; }

    public string Name { get; set; }
}

