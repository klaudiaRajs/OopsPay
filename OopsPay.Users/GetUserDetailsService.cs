using Contracts.Users;
using Users.Repos;

namespace Users;

public class GetUserDetailsService(
    GetUserDetailsRepo getUserDetailsRepo,
    ReturnResponseToTransactionRepo returnResponseToTransactionRepo)
{
    public bool Get(GetUserDetails userDetails)
    {
        var request = GetUserDetailsRequest.FromPayload(userDetails.Payload);
        var user = getUserDetailsRepo.Get(request);
        if (user == null)
        {
            //TODO wyślij stworzenie nowego użytkownika z danych 
            return false;
        }

        var wasSavingSuccessful = returnResponseToTransactionRepo.Return(userDetails, user);
        if (!wasSavingSuccessful)
        {
            //TODO dodaj log 
            //TODO zwieksz ilosc bledów 
            return false;
        }

        return true;
    }
}