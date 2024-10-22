using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface iTokenService // interface linking the service to the controller
    {
        string createToken( User user);
        
    }
}