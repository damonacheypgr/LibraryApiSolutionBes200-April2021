using LibraryApi.Controllers;
using System;
using System.Threading.Tasks;

namespace LibraryApi
{
    public interface ILookupOnCallDevelopers
    {
        Task<OnCallDeveloperResponse> GetOnCallDeveloperAsync();
    }
}