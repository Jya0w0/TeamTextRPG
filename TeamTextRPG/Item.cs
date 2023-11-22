using System;
using System.Collections;
namespace TeamTextRPG
{
    public class Item
    {
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public string ItemLevel { get; set; }
        public ItemType Type { get; set; }
        public int ItemAtk { get; set; }
        public int ItemDef { get; set; }
        public int ItemHp { get; set; }
        public bool Have { get; set; } = false;
        public bool Equip { get; set; } = false;

        public Item(ItemType type, string itemLevel, string itemName, int itemAtk, int itemDef, int itemHp, string itemDescription, bool have, bool equip)
        {
            Type = type;
            ItemLevel = itemLevel;
            ItemName = itemName;
            ItemAtk = itemAtk;
            ItemDef = itemDef;
            ItemHp = itemHp;
            ItemDescription = itemDescription;
            Have = have;
            Equip = equip;
        }

        public enum ItemType
        {
            무기,
            무기_소방관,
            무기_군인,
            무기_의사,
            방어구_머리,
            방어구_상의,
            방어구_하의
        }
        
        public static List<Item> ItemList()
        {
            List<Item> itemList = new List<Item>();

            
            //무기

            //기본
            itemList.Add(new Item(Item.ItemType.무기, "기본", "막대기", 5, 0, 0, "바닥에서 주워왔습니다.", true, false));

            //일반
            itemList.Add(new Item(Item.ItemType.무기, "일반", "곤봉", 15, 0, 0, "경찰이 썻던 무기같다.", false, false));
            itemList.Add(new Item(Item.ItemType.무기_소방관, "일반", "수술용 메스", 15, 0, 0, "이걸로 뭘한걸까 피로흥건하다.", false, false));
            itemList.Add(new Item(Item.ItemType.무기_군인, "일반", "개조한 비비탄총", 10, 0, 0, "쓸만한 정도로 개조했습니다.", false, false));
            itemList.Add(new Item(Item.ItemType.무기_의사, "일반", "주사기", 8, 0, 0, "치료용이지만 날카롭습니다.", false, false));

            //고급
            itemList.Add(new Item(Item.ItemType.무기_소방관, "고급", "식칼", 25, 0, 0, "식당에서 요리하던 칼같습니다.", false, false));
            itemList.Add(new Item(Item.ItemType.무기_군인, "고급", "권총", 27, 0, 0, "권총있있는데 탄환이 이상합니다.", false, false));
            itemList.Add(new Item(Item.ItemType.무기_의사, "고급", "약품세트", 10, 0, 0, "몬스터에게는 해로운 약품이 분명있을겁니다.", false, false));

            //특별
            itemList.Add(new Item(Item.ItemType.무기_소방관, "특별", "전기창", 75, 0, 0, "막대기끝에 식칼을 달고 전기가 흐르게 개조했습니다.", false, false));
            itemList.Add(new Item(Item.ItemType.무기_군인, "특별", "기관총", 75, 0, 0, "기관총은있는데 탄환이 이상합니다.", false, false));
            itemList.Add(new Item(Item.ItemType.무기_의사, "특별", "화학약품세트", 75, 0, 0, "살상력 있는 약품들로 가득합니다.", false, false));


            //상의 방어구

            //기본
            itemList.Add(new Item(Item.ItemType.방어구_상의, "기본", "나시", 0, 1, 1, "방어에 도움이 될지 의문입니다.", true, false));

            //일반
            itemList.Add(new Item(Item.ItemType.방어구_상의, "일반", "허름한 소방복 상의", 0, 3, 10, "낡아서 여기저기 구멍이 뚫려있습니다.", false, false));
            itemList.Add(new Item(Item.ItemType.방어구_상의, "일반", "찢어진 연구복 상의", 0, 1, 30, "비바람은 어느정도 막아줄수있을것 같습니다..", false, false));

            //고급
            itemList.Add(new Item(Item.ItemType.방어구_상의, "고급", "방탄복 상의", 0, 10, 20, "총도 막을 수 있을거 같습니다.", false, false));
            itemList.Add(new Item(Item.ItemType.방어구_상의, "고급", "연구용 슈트 상의", 0, 3, 90, "연구원들이 실험체를 대상으로 사용했던것 같습니다.", false, false));

            //특별
            itemList.Add(new Item(Item.ItemType.방어구_상의, "특별", "MK.50 나노테크 슈트 상의", 0, 50, 200, "나노 입자 저장부에서 나노 단위로 보관된 슈트를 시동 및 사출시켜 착용합니다", false, false));
        
            //하의 방어구

            //기본
            itemList.Add(new Item(Item.ItemType.방어구_하의, "기본", "낡은 바지", 0, 1, 1, "없는것보다는 좋을듯 합니다.", true, false));

            //일반
            itemList.Add(new Item(Item.ItemType.방어구_하의, "일반", "허름한 소방복 하의", 0, 4, 6, "낡아서 여기저기 구멍이 뚫려있습니다.", false, false));
            itemList.Add(new Item(Item.ItemType.방어구_하의, "일반", "찢어진 연구복 하의", 0, 0, 40, "여기저기 찢어져있습니다.", false, false));

            //고급
            itemList.Add(new Item(Item.ItemType.방어구_하의, "고급", "방탄복 하의", 0, 15, 10, "총도 막을 수 있을거 같습니다.", false, false));
            itemList.Add(new Item(Item.ItemType.방어구_하의, "고급 ", "연구용 슈트 하의", 0, 5, 110, "연구원들이 실험체를 대상으로 사용했던것 같습니다.", false, false));

            //특별
            itemList.Add(new Item(Item.ItemType.방어구_하의, "특별", "MK.50 나노테크 슈트 하의", 0, 40, 400, "나노 입자 저장부에서 나노 단위로 보관된 슈트를 시동 및 사출시켜 착용합니다", false, false));

            //머리 방어구

            //기본
            itemList.Add(new Item(Item.ItemType.방어구_머리, "기본", "KF마스크", 0, 1, 1, "이 험한 시대에 병을 막아주는 필수적인 마스크입니다.", false, false));

            //일반
            itemList.Add(new Item(Item.ItemType.방어구_머리, "일반", "야구모자", 0, 4, 4, "야구공 정도는 무리없이 막을 수 있습니다.", false, false));
            itemList.Add(new Item(Item.ItemType.방어구_머리, "일반", "냄비", 0, 2, 10, "수프 찌꺼기가 있습니다.", false, false));

            //고급
            itemList.Add(new Item(Item.ItemType.방어구_머리, "고급", "방탄모", 0, 10, 40, "총알도 막을 수 있습니다.", false, false));
            itemList.Add(new Item(Item.ItemType.방어구_머리, "고급", "연구용 모자", 0, 6, 80, "실험체를 대상으로 썻던거 같습니다.", false, false));

            //특별
            itemList.Add(new Item(Item.ItemType.방어구_머리, "특별", "MK.50 나노테크 투구", 0, 40, 200, "나노 입자 저장부에서 나노 단위로 보관된 슈트를 시동 및 사출시켜 착용합니다", false, false));

            return itemList;
        }
        //static void GameDataSattingItem()
        //{
        //    AddItem(new Item("무쇠갑옷", "무쇠로 만들어져 튼튼한 갑옷입니다.", Item.ItemType.Body, 0, 5, 0));
        //    AddItem(new Item("낡은 검", "쉽게 볼 수 있는 낡은 검입니다.", Item.ItemType.Weapon, 2, 0, 0));
        //    AddItem(new Item("고양이 수염", "고양이 수염은 행운을 가져다 줍니다. 야옹!", Item.ItemType.Acc, 7, 7, 7));
        //}
    }
}