using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SendersTutorial.Utils {
    public interface ISender<T> where T : Message {
        Task<bool> SendAsync(T message);
    }
}