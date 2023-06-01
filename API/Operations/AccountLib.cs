using API.Operations.Interfaces;

namespace API.Operations;

public sealed class AccountLib : IAccountLib
{
    private string[] _values = { "Hotel ACME1", "Hotel ACME2", "Hotel ACME3", "Hotel ACME4", "Hotel ACME5", "Hotel ACME6", };

    public AccountLib(IConfiguration configuration)
    {
    }

    public string[] GetValueList() => _values;

    public string GetValueById(int id) => _values.Length <= id ? string.Empty : _values[id];

    public int AddValue(string value) => 1;

    public int UpdateValue(string value, int id) => _values.Length <= id ? -1 : 1;

    public int DeleteValue(int id) => _values.Length <= id ? -1 : 1;

}
