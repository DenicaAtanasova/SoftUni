function solve() {
    document.getElementsByTagName('button')[0].addEventListener('click', (event) => {
        event.preventDefault();

        let user = {
            username : document.querySelector('input[placeholder="username"]').value,
            password : document.querySelector('input[placeholder="password"]').value,
            email : document.querySelector('input[placeholder="email"]').value,
            topics : Array.from(document.querySelectorAll('input[type="checkbox"]'))
                          .filter(x=>x.checked)
                          .map(x => x.value)
                          .join(' ')
        }

        fillRow(user);
    });

    let tbodyElement = document.querySelector('tbody');  
    let tdElement = document.createElement('td');

    function fillRow(user){
        let trElement = document.createElement('tr');
        
        trElement.appendChild(fillData(user.username));
        trElement.appendChild(fillData(user.email));
        trElement.appendChild(fillData(user.topics));
        
        tbodyElement.appendChild(trElement);
    }

    function fillData(userProperty){
        let td = tdElement.cloneNode();
        td.innerHTML = userProperty;
        return td
    }

    document.getElementsByTagName('button')[1].addEventListener('click', () => {
        let str = document.getElementsByTagName('input')[7].value;
    
        let tds = Array.from(document.querySelectorAll('table tbody tr td'));
        
        for (let td of tds) {
            td.parentNode.style.visibility = 'hidden';
        }
        
        for (let td of tds) {
            if (td.textContent.includes(str)) {
            td.parentNode.style.visibility = 'visible';
            }
        }
    });
}   