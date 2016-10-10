using Devinmotion.Dashboard.Model.Models;
using System.Collections.Generic;

namespace Devinmotion.Dashboard.Model.Services
{
    public interface IBirthdayRepository
    {
        IEnumerable<Birthday> LoadBirthdays();
    }
}
