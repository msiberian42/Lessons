using System;

public static class Bank
{
    private static BankInteractor bankInteractor;

    public static event Action OnBankInitializedEvent;

    public static int coins
    {
        get
        {
            CheckClass();
            return bankInteractor.coins;
        }
    }
    public static bool isInitialized { get; private set; }

    public static void Initialize(BankInteractor interactor)
    {
        bankInteractor = interactor;
        isInitialized = true;

        OnBankInitializedEvent?.Invoke();
    }

    public static bool IsEnoughCoins(int value)
    {
        CheckClass();
        return bankInteractor.IsEnoughCoins(value);
    }

    public static void AddCoins(object sender, int value)
    {
        CheckClass();
        bankInteractor.AddCoins(sender, value);
    }
    public static void Spend(object sender, int value)
    {
        CheckClass();
        bankInteractor.Spend(sender, value);
    }
    private static void CheckClass()
    {
        if (!isInitialized)
            throw new Exception("Bank is not initialized yet");
    }
}
