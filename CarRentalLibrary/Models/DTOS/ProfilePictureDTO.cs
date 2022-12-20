using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsDap.Models.DTOS
{
    public class ProfilePictureDTO
    {
        public int UserId { get; set; }
        public string PictureAsBase64 { get; set; }
    }
}
