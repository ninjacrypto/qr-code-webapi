using API.Models;
using API.Operations.Interfaces;
using Core.Lib.Utilities.Interfaces;

namespace API.Operations;

public class AuthLib : IAuthLib
{
    #region [Declarations]

    private const string _user = "User";
    private const string _admin = "Admin";
    private readonly IConfiguration _configuration;
    private IJwtUtils _jwtTokenBuilder;
    private readonly ILogger _logger;

    #endregion [Declarations]

    public AuthLib(IConfiguration configuration, IJwtUtils jwtTokenBuilder, ILogger<AuthLib> logger)
    {
        _configuration = configuration;
        _jwtTokenBuilder = jwtTokenBuilder;
        _logger = logger;
    }

    public int ValidateLogin(LoginDTO login)
    {
        try
        {
            _logger.LogInformation("Login validation started");

            if (login.UserName == _user && login.Password == "user password")
            {
                return 1;
            }
            else if (login.UserName == _admin && login.Password == "admin password")
            {
                return 1;
            }
            else if (login.UserName == _user && login.Password == "invalid password")
            {
                return -103; // invalid credential
            }
            else if (login.UserName == _user && login.Password == "deleted password")
            {
                return -104; // account deleted
            }
            else if (login.UserName == "No one" && login.Password == "no one password")
            {
                throw new Exception("This is an excpetion");
            }
            return -102; // account not found
        }
        catch (Exception ex)
        {
            _logger.LogError("ValidateLogin - {message}", ex.Message);
            return -1;
        }
    }

    public string GenerateToken(string userId, string userRole = null, string userName = null, string companyId = null)
    {
        ArgumentException.ThrowIfNullOrEmpty(userId);

        _jwtTokenBuilder
            .AddSecurityKey(_configuration["AppConfig:JWT:Key"])
            .AddIssuer(_configuration["AppConfig:JWT:Issuer"])
            .AddAudience(_configuration["AppConfig:JWT:Audience"])
            .AddExpiry(Convert.ToInt32(_configuration["AppConfig:JWT:HoursValid"]))
            .AddRole(userRole)
            .AddName(userName)
            .AddUserId(userId)
            .AddCompanyId(companyId);

        return _jwtTokenBuilder.GenerateToken();
    }
}
