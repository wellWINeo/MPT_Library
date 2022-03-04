namespace Library.Services;

/// <summary>
/// Состояния меню
/// </summary>
public enum MenuState
{
    /// <summary>Аутентификация</summary>
    Auth,
    
    /// <summary>Восстановление доступа</summary>
    Recover,
    
    /// <summary>Переход в главное меню</summary>
    Menu
}