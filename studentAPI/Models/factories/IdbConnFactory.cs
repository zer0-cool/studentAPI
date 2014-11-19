using System;
using System.Data;
namespace studentAPI.Models.factories
{
    //This class will serve up instances 'SqlConnection' when CreateConnection is invoked
    //The connection string is provided via web.config and set in /App_Start/NinjectWebCommon
    //in the RegisterServices function. 

    //Found this months ago on SO, and thought it was excellent. 
    //Credit: http://stackoverflow.com/questions/14523166/is-there-a-simple-way-to-use-dependency-injection-on-my-connections

    public interface IdbConnFactory
    {
        IDbConnection CreateConnection();
    }
}
