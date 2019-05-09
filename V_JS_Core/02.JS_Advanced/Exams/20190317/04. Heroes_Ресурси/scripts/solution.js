function solve(){
   let kingdoms = {castle:{}, dungeon:{}, fortress:{}, inferno:{}, necropolis:{}, rampart:{}, stronghold:{}, toweer:{}, conflux:{}};

   $('#kingdom button').click(rebuild);
   $('#characters button').click(join);
   $('#actions button').click(attack);

   function rebuild(){
      let $kingdom = $('#kingdom input[placeholder="Kingdom..."]').val().toLowerCase();
      let $king = $('#kingdom input[placeholder="King..."]').val().toLowerCase();

      if(typeof $king === 'string' &&
         $king.length >= 2 &&
         kingdoms.hasOwnProperty($kingdom) &&
         Object.keys(kingdoms[$kingdom]).length === 0){
         
         kingdoms[$kingdom] = {
            kingdomName: $kingdom,
            kingName: $king,
            tank:0,
            fighter:0,
            mage:0,
            characters:[],
            updateArmy: function(characterName, characterType){
               
               this[characterType] += 1;
               let pElements = $(`#${this.kingdomName}`).find($('p'));
               pElements[0].textContent = `TANKS - ${this.tank}`;
               pElements[1].textContent = `FIGHTERS - ${this.fighter}`;
               pElements[2].textContent = `MAGES - ${this.mage}`;

               if(characterName !== undefined){
                  this.characters.push(characterName);
                  $(`#${this.kingdomName} .armyOutput`).text(this.characters.join(', '));
               }
            },
            getAttackPoints(){
               return this.tank * 20 + this.fighter * 50, this.mage * 70;
            },
            getDefencePoints(){
               return this.tank * 80 + this.fighter * 50, this.mage * 30;
            },
            changeKingName(name){
               $(`#${this.kingdomName} h2`).text(name.toUpperCase());
               this.kingName = name;
            }
         };
         
         $(`#${$kingdom}`).css('display', 'block')
            .append($('<h1>').text($kingdom.toUpperCase()))
            .append($('<div>').addClass('castle'))
            .append($('<h2>').text($king.toUpperCase()))
            .append($('<fieldset>')
               .append($('<legend>').text('Army'))
               .append($('<p>'))
               .append($('<p>'))
               .append($('<p>'))
               .append($('<div>').addClass('armyOutput')));


         kingdoms[$kingdom].updateArmy();
      } else{
         $('#kingdom input[placeholder="Kingdom..."]').val('');
         $('#kingdom input[placeholder="King..."]').val('');
      }
   }

   function join(){
      let $kingdom = $('#characters input[placeholder="Kingdom..."]').val().toLowerCase();
      let $characterName = $('#characters input[placeholder="Character..."]').val();
      let $characterType = $('input[type=radio]:checked').val();

      if(typeof $characterName === 'string' &&
         $characterName.length >= 2 &&
         kingdoms.hasOwnProperty($kingdom) &&
         Object.keys(kingdoms[$kingdom]).length > 0 &&
         $characterType){

         kingdoms[$kingdom].updateArmy($characterName, $characterType);
      } else{
         $('#characters input[placeholder="Character..."]').val('');
         $('#characters input[placeholder="Kingdom..."]').val('');
      }
   }
   
   function attack(){
      let $attacker = $('input[placeholder="Attacker..."]').val().toLowerCase();
      let $defender = $('input[placeholder="Defender..."]').val().toLowerCase();

      if(kingdoms.hasOwnProperty($attacker) && kingdoms.hasOwnProperty($defender)){
         if(kingdoms[$attacker].getAttackPoints() > kingdoms[$defender].getDefencePoints()){
            
            kingdoms[$defender].changeKingName(kingdoms[$attacker].kingName);
         }
      } else{
         $('input[placeholder="Attacker..."]').val('');
         $('input[placeholder="Defender..."]').val('')
      }
   }
}
solve()