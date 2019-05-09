// function solve() {
//    let prices = {
//       'JS-Fundamentals':170,
//       'JS-Advanced':180,
//       'JS-Applications':190,
//       'JS-Web':490
//    };

//    $('button').click(function(){
//       let totalPrice = 0;
//       let courses = [];

//       $('input[type=checkbox]:checked').each((idx, el) =>{
//          let courseName = el.parentNode.children[1].textContent.split(' - ')[0].replace(' ', '-');
//          $('#myCourses .courseBody ul')
//          .append($('<li>').text(courseName));

//          courses.push(courseName);
//       });

//       if(courses. length > 0){
//          totalPrice = courses.map(course => prices[course]).reduce((acc, x) => acc + x);
//       }

//       if(courses.includes('JS-Fundamentals') && courses.includes('JS-Advanced')){
//          totalPrice -= prices['JS-Advanced'] * 0.1;     
//       }
//       console.log(totalPrice);
//       if(courses.includes('JS-Fundamentals') && courses.includes('JS-Advanced') && courses.includes('JS-Applications')){        
//          totalPrice -=  (totalPrice - prices['JS-Web']) * 0.06;     
//       }
//       console.log(totalPrice);
//       if(courses.length > 3){
//          $('#myCourses .courseBody ul')
//          .append($('<li>').text('HTML and CSS'));
//       }

//       if($('input[type=radio]:checked').val() === 'online'){
//          totalPrice *= 0.94;
//       }

//       $('.courseFoot p').text(`Cost: ${Math.floor(totalPrice)}.00 BGN`);         
//    });
// }

function solve() {
   let prices = {
      'JS Fundamentals': 170,
      'JS Advanced': 180,
      'JS Applications': 190,
      'JS Web': 490
   }
 
   let totalPrice = 0;
   let check = 0;
 
   $('button').on('click', function () {
      let inputArr = document.getElementsByTagName('input');
 
      if ($(inputArr[0]).is(':checked') && $(inputArr[1]).is(':checked')
         && $(inputArr[2]).is(':checked') && $(inputArr[3]).is(':checked')){
         totalPrice = (170 + 180 * 0.90 + 190) * 0.94 + 490;
         check = 1;
      } else if ($(inputArr[0]).is(':checked') && $(inputArr[1]).is(':checked')
               && $(inputArr[2]).is(':checked')){
         totalPrice = (170 + 180 * 0.90 + 190) * 0.94;
      } else if ($(inputArr[0]).is(':checked') && $(inputArr[1]).is(':checked')) {
         totalPrice = 170 + 180 * 0.90;
      } else {
         for (let i = 0; i <= 3; i++) {
            if ($(inputArr[i]).is(':checked')) {
               let el =  $(inputArr[i]).next().text().split(' - ')[0];
               totalPrice += prices[el]
            }
         }
      }
 
      for (let i = 0; i <= 3; i++) {
         let print = document.getElementsByClassName('courseBody')[1].children;
         let ul = print[0];
 
         if ($(inputArr[i]).is(':checked')) {
            let li = document.createElement('li')
            $(li).text($(inputArr[i]).next().text().split('-')[0].replace(' ', '-').trim())
            ul.appendChild(li)
         }
      }
      if (check) {
         let print = document.getElementsByClassName('courseBody')[1].children;
         let ul = print[0];
         let li = document.createElement('li')
         $(li).text('HTML and CSS')
         ul.appendChild(li)
      }
 
      if ($(inputArr[5]).is(':checked')) {
         totalPrice = totalPrice * 0.94
      }
 
      if (totalPrice) {
         $('.courseFoot p').text(`Cost: ${Math.floor(totalPrice)}.00 BGN`);
      }
   })
}
solve()