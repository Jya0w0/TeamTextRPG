public class items

{
    public enum ItemType
     {
            Weapon,
            Head,
            Body,
            Pants,
       }

    public string ItemName { get; set; }
    public string ItemDescription { get; set; }
    public string ItemLevel { get; set; }
    public ItemType Type { get; set; }
    public int ItemAtk { get; set; }
    public int ItemDef { get; set; }
    public int ItemHp { get; set; }
    public bool Equiped { get; set; } = false;

    public items(ItemType type, string itemlevel, string itemname,int itematk, int itemdef, int itemhp, string itemdescription)
    {
        ItemName = itemname;
        ItemDescription = itemdescription;
        ItemLevel = itemlevel;
        Type = type;
        ItemAtk = itematk;
        ItemDef = itemdef;
        ItemHp = itemhp;
        
    }
}
public class program
{

    static void item()
    {
        List<items> itemlist = new List<items>();

        //아이템 리스트
        //무기
        itemlist.Add(new items(items.ItemType.Weapon, "[일반 무기]", "곤봉", 5, 0, 0, "경관이 범죄자를 때려잡기 위해 써왔던 유서 깊은 무기입니다."));
        itemlist.Add(new items(items.ItemType.Weapon, "[일반 무기]", "블랙잭",  7, 0, 0, "사용하기 간단하면서도 어려운 고대의 무기입니다."));
        itemlist.Add(new items(items.ItemType.Weapon, "[일반 무기]", "야구방망이", 10, 0, 0, "한때는 스포츠를 하기위해 사용되었지만 이제는 아닙니다."));
        itemlist.Add(new items(items.ItemType.Weapon, "[일반 무기]", "외날검", 13, 0, 0, "인류역사상 가장 많이 사용된 무기중하나 입니다.."));
        itemlist.Add(new items(items.ItemType.Weapon, "[일반 무기]", "활", 19, 0, 0, "최.종.병.기."));
        itemlist.Add(new items(items.ItemType.Weapon, "[고급 무기]", "컴포지트 보우", 24, 0, 0, "과거 한 민족이 매우 잘다뤘던 무기입니다."));
        itemlist.Add(new items(items.ItemType.Weapon, "[고급 무기]", "권총", 27, 0, 0, "거리가 멀어도 적을 상대할수있는 무기입니다."));
        itemlist.Add(new items(items.ItemType.Weapon, "[고급 무기]", "기관단총", 30, 0, 0, "연사력이 좋은 총입니다."));
        itemlist.Add(new items(items.ItemType.Weapon, "[고급 무기]", "소총", 35, 0, 0, "군인들의 보편적인 무기입니다.."));
        itemlist.Add(new items(items.ItemType.Weapon, "[특별 무기]", "로켓런쳐", 75, 0, 0, "좀비라 불리던 존재들의 악몽과도 같은 무기입니다."));

        //상의 방어구
        itemlist.Add(new items(items.ItemType.Body, "[일반 상의]", "허름한 티셔츠", 0, 3, 1, "낡아서 여기저기 구멍이 뚫려있습니다."));
        itemlist.Add(new items(items.ItemType.Body, "[일반 상의]", "후드티", 0, 5, 2, "비바람은 어느정도 막아줄수있을것 같습니다.."));
        itemlist.Add(new items(items.ItemType.Body, "[일반 상의]", "두꺼운 패딩", 0, 7, 4, "몸을 보호하는데 좋을것 같습니다."));
        itemlist.Add(new items(items.ItemType.Body, "[일반 상의]", "롱코트", 0, 9, 6, "튼튼한소재로 만들어져 몸을 보호해줍니다."));
        itemlist.Add(new items(items.ItemType.Body, "[고급 상의]", "방탄복", 0, 12, 8, "공격을 흡수해주는 튼튼한 방어구"));
        itemlist.Add(new items(items.ItemType.Body, "[고급 상의]", "가죽 상의 갑옷", 0, 15, 10, "상체를 전부 감싸는 갑옷 움직이기도 편합니다."));
        itemlist.Add(new items(items.ItemType.Body, "[고급 상의]", "철제 상의 갑옷", 0, 18, 14, "조금 무겁지만 매우 단단합니다."));
        itemlist.Add(new items(items.ItemType.Body, "[고급 상의]", "충격흡수 슈트 상의", 0, 21, 17, "충격을 분산해 강력한 공격도 아프지않게 해줍니다."));
        itemlist.Add(new items(items.ItemType.Body, "[특별 상의]", "MK.50 나노테크 슈트 상의", 0, 45, 50, "나노 입자 저장부에서 나노 단위로 보관된 슈트를 시동 및 사출시켜 착용합니다"));

        //하의 방어구
        itemlist.Add(new items(items.ItemType.Pants, "[일반 하의]", "낡은 바지", 0, 2, 2, "없는것보다는 좋을듯 합니다."));
        itemlist.Add(new items(items.ItemType.Pants, "[일반 하의]", "청 바지", 0, 4, 4, "데님소재로 만들어 착용감도 좋고 디자인도 나쁘지않습니다."));
        itemlist.Add(new items(items.ItemType.Pants, "[일반 하의]", "트레이닝 바지", 0, 6, 6, "격한움직임에도 잘늘어나는 매우 튼튼한 소재로 되있습니다."));
        itemlist.Add(new items(items.ItemType.Pants, "[고급 하의]", "야전 하의", 0, 8, 8, "위장 무늬가 그려져있어 숨으면 잘 안보일것 같습니다."));
        itemlist.Add(new items(items.ItemType.Pants, "[고급 하의]", "가죽 하의 갑옷", 0, 10, 10, "조금 질기지만 튼튼합니다.."));
        itemlist.Add(new items(items.ItemType.Pants, "[고급 하의]", "철제 하의 갑옷", 0, 12, 12, "무거운것만 제외하면 매우 든든합니다."));
        itemlist.Add(new items(items.ItemType.Pants, "[고급 하의]", "충격흡수 슈트 하의", 0, 18, 14, "충격을 분산해 강력한 공격도 아프지않게 해줍니다."));
        itemlist.Add(new items(items.ItemType.Pants, "[특별 하의]", "MK.50 나노테크 슈트 하의", 0, 40, 35, "나노 입자 저장부에서 나노 단위로 보관된 슈트를 시동 및 사출시켜 착용합니다"));

        //머리 방어구
        itemlist.Add(new items(items.ItemType.Head, "[일반 머리]", "KF마스크", 0, 2, 1, "이 험한 시대에 병을 막아주는 필수적인 마스크입니다."));
        itemlist.Add(new items(items.ItemType.Head, "[일반 머리]", "목도리", 0, 1, 2, "추위를 막아주는 따뜻한 친구입니다."));
        itemlist.Add(new items(items.ItemType.Head, "[일반 머리]", "스포츠 모자", 0, 2, 3, "자외선을 조금이나마 막을수있습니다."));
        itemlist.Add(new items(items.ItemType.Head, "[일반 머리]", "선글라스", 0, 3, 2, "강력한 빛으로부터 눈을 보호해 줍니다."));
        itemlist.Add(new items(items.ItemType.Head, "[고급 머리]", "광대가면", 0, 3, 3, "웃어서 죄송해요. 전 가면을 쓰고있어요."));
        itemlist.Add(new items(items.ItemType.Head, "[고급 머리]", "방한모자", 0, 4, 7, "겨울철 구수한냄새와 함께 찾아오는분의 상징."));
        itemlist.Add(new items(items.ItemType.Head, "[고급 머리]", "가죽 투구", 0, 7, 5, "머리를 보호해줍니다. 아마도...."));
        itemlist.Add(new items(items.ItemType.Head, "[고급 머리]", "철제 투구", 0, 10, 5, "머리를 확실히 보호해줍니다."));
        itemlist.Add(new items(items.ItemType.Head, "[고급 머리]", "충격흡수 투구", 0, 13, 8, "더이상 무서울게 없습니다."));
        itemlist.Add(new items(items.ItemType.Head, "[특별 머리]", "MK.50 나노테크 투구", 0, 25, 20, "나노 입자 저장부에서 나노 단위로 보관된 슈트를 시동 및 사출시켜 착용합니다"));
    }
}
