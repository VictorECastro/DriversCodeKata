using CodeKata_Drivers.Models;
using CodeKata_Drivers.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CodeKata_Drivers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessController : ControllerBase
    {
        List<Driver> drivers;
        DriverRepo dr;
        TripRepo tr;

        [HttpGet]
        public ActionResult Get()
        {
            return Ok("Message Received");
        }

        [HttpPost, DisableRequestSizeLimit]
        public async Task<IActionResult> Upload()
        {
            try
            {

                var formCollection = await Request.ReadFormAsync();
                var file = formCollection.Files.First();
                var folderName = Path.Combine("Resources", "Files");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if(file.Length > 0)
                {
                    drivers = new List<Driver>();
                    dr = new DriverRepo();
                    tr = new TripRepo();
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    string line = "";
                    int ct = 0;
                    using (StreamReader rd = new StreamReader(dbPath))
                    {
                        while((line = rd.ReadLine()) != null)
                        {
                            if (ct == 0)
                            {
                                if(validLine(line))
                                {
                                    ProcessLine(line);
                                    ct++;
                                }
                                else
                                {
                                    ct++;
                                    return BadRequest("Invalid File!!!");
                                }
                            }
                            else
                            {
                                ProcessLine(line);
                                ct++;
                            }
                        }
                    }

                    return Ok(CalculateSpeed());
                }
                else
                {
                    return BadRequest("File does not contain data");
                }
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }

        }

        private bool validLine(string line)
        {
            string[] lineArr = line.Split(new char[0]);
            if (lineArr.Length > 0)
            {
                if (lineArr[0] == "Driver")
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        private string CalculateSpeed()
        {
            StringBuilder st = new StringBuilder();
            
            foreach (Driver d in drivers)
            {

                st.AppendLine(dr.GetDriverReport(d));
               
            }
            return st.ToString();
        }

        private void ProcessLine(string line)
        {
            string[] lineArr = line.Split(new char[0]);

            if (lineArr.Length > 0)
            {
                switch (lineArr[0])
                {
                    case "Driver":
                        drivers.Add(dr.AddDriver(lineArr[1], drivers));
                        break;
                    case "Trip":
                        drivers = tr.GetTripToAdd(lineArr[1], lineArr[2], lineArr[3], lineArr[4], drivers);
                        break;
                }
            }
        }
    }
}
