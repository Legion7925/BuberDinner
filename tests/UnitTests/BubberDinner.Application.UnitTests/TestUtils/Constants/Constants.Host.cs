using BubberDinner.Domain.Host.ValueObjects;

namespace BubberDinner.Application.UnitTests.TestUtils;

public static partial class Constants
{
    public static class Host
    {
        public static readonly HostId Id = HostId.Create(new Guid("00000000-0000-0000-0000-000000000000"));
    }
}
