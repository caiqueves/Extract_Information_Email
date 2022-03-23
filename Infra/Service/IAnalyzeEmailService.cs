using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Extract_Information_SalesForce.Infra.Service
{
    public interface IAnalyzeEmailService
    {
        string ReturnIdSalesForce(string emailFile);
    }
}
