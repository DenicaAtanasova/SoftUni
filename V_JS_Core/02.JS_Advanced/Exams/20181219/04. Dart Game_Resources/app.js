function dart(){
	function getPoints(index){
		return Number($('#scoreBoard tr')[index].children[1].textContent.split(' ')[0]);
	}

	function changeBackgroundColor(winner, loser){
		winner.style.background = 'green';
		loser.style.background = 'red';
	}

	let scoreboard = {
		firstLayer : getPoints(1),
		secondLayer : getPoints(2),
		thirdLayer : getPoints(3),
		fourthLayer : getPoints(4),
		fifthLayer : getPoints(5),
		sixthLayer : getPoints(6)
	}

	let players = {
		'Home' : $('#Home p')[0],
		'Away' : $('#Away p')[0]
	}

	function checkIfGameIsOver(){
		if(Number(players['Home'].textContent) >= 100){
			changeBackgroundColor($('#Home p')[1], $('#Away p')[1]);
			return true;
		}
		if(Number(players['Away'].textContent) >= 100){
			changeBackgroundColor($('#Away p')[1], $('#Home p')[1]);
			return true;
		}

		return false;
	}

	let currentPlayer = 'Home';
	$('#playBoard div').on('click', (e) =>{
		e.stopPropagation();
		
		if(!checkIfGameIsOver()){
			players[currentPlayer].textContent = +players[currentPlayer].textContent + scoreboard[e.target.id];
			$('#turns p')[1].textContent = `Next is ${currentPlayer}`;

			if (currentPlayer === 'Away') {
				currentPlayer = 'Home';
			} else {
				currentPlayer = 'Away';
			}

			$('#turns p')[0].textContent = `Turn on ${currentPlayer}`;
			checkIfGameIsOver();
		}
	});
}	