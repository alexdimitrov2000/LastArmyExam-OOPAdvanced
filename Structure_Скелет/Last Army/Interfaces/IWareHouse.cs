public interface IWareHouse
{
    void AddAmmunition(string ammunition, int quantity);
    void EquipArmy(IArmy army);
    bool TryEquipSoldier(ISoldier soldier);
}