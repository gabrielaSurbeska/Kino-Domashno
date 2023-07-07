
using Kino.Domain.Identity;
using System.Collections.Generic;

namespace Kino.Repository.Interface
{
    public interface IUserReopsitory
    {
        IEnumerable<KinoUser> GetAll();
        KinoUser Get(string id);
        void Insert(KinoUser user);
        void Update(KinoUser user);
        void Delete(KinoUser user);

    }
}
