using Itmo.ObjectOrientedProgramming.Lab3.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services.Addressees;

public interface IAddressee
{
    void ReceiveMessage(Message message);
}