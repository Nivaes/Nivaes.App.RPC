using System;
using System.Collections.Generic;
using System.Text;
using MemoryPack;
using Nivaes.App.RPC.Sample;
using Nivaes.DataTestGenerator;

namespace Nivaes.App.Rpc.Test.Serializer
{
    public class SerializeTest
    {
        [Fact]
        public void SerializerModel()
        {
            var contact = ContactGenerator.GenerateContact();

            var user = new UserDataModel
            {
                IdUser = Guid.NewGuid(),
                Identification = $"ID00000",
                Name = contact.SortName,
                GivenName = contact.GivenName,
                FamilyName = contact.FamilyName,
                Email = contact.Email,
                PhoneNumber = contact.TelephoneNumber,
                TimeStamp = DateTime.UtcNow
            };

            var bin = MemoryPackSerializer.Serialize(user);
            var userCopy = MemoryPackSerializer.Deserialize<UserDataModel>(bin);

            userCopy.ShouldNotBeNull();
            userCopy.Id.ShouldBe(user.Id);
            userCopy.IdUser.ShouldBe(user.IdUser);

            userCopy.IdUser.ShouldBe(user.IdUser);
            userCopy.Identification.ShouldBe(user.Identification);
            userCopy.Name.ShouldBe(user.Name);
            userCopy.GivenName.ShouldBe(user.GivenName);
            userCopy.FamilyName.ShouldBe(user.FamilyName);
            userCopy.Email.ShouldBe(user.Email);
            userCopy.IdUser.ShouldBe(user.IdUser);
            userCopy.PhoneNumber.ShouldBe(user.PhoneNumber);
            userCopy.TimeStamp.ShouldBe(user.TimeStamp);
        }
    }
}
