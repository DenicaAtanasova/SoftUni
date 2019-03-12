function realEstateAgency () {
	let $rent = $('input[name=apartmentRent]');
	let $apartment = $('input[name=apartmentType]');
	let $commission = $('input[name=agencyCommission]');

	let $budget = $('input[name=familyBudget]');
	let $searchedApartment = $('input[name=familyApartmentType]');
	let $familyName = $('input[name=familyName]');

	function validateRegFields(){
		let isValidRentPrice = !isNaN($rent.val()) && $rent.val() > 0;
		let isValidAppartmentType = $apartment.val() !== '' && !$apartment.val().includes(':');
		let isValidCommission = !isNaN($commission.val()) && $commission.val() >= 0 && $commission.val() <= 100;

		return isValidRentPrice && isValidAppartmentType && isValidCommission;
	}

	function validateFindFields(){
		let isValidBudget = $budget.val() > 0;
		let isValidAppartmentType = $searchedApartment.val() !== '';
		let isValidFamilyName = $familyName.val() !== '';

		return isValidBudget && isValidAppartmentType && isValidFamilyName;
	}

	function resetFields(firstField, secondField, thirdField){
		firstField.val('');
		secondField.val('');
		thirdField.val('');
	}

	$('button[name=regOffer]').on('click', regOffer);

	function regOffer(){

		let message;
		if(validateRegFields()){
			message = 'Your offer was created successfully.';

			$('<div>').addClass('apartment')			
					  .append($(`<p>Rent: ${$rent.val()}</p>`))
					  .append($(`<p>Type: ${$apartment.val()}</p>`))
					  .append($(`<p>Commission: ${$commission.val()}</p>`))
					  .appendTo($('#building'));		

		}else{
			message = 'Your offer registration went wrong, try again.';
		}

		$('#message').text(message);
		resetFields($rent, $apartment, $commission);
	}

	$('button[name=findOffer]').on('click', findOffer);

	let profit = 0;
	function findOffer(){
		if (validateFindFields()) {
			$.each($('.apartment'), function () {
				let isFoundApartmentType = this.children[1].textContent.split(' ')[1] === $searchedApartment.val();	
				
				let rent = Number(this.children[0].textContent.split(' ')[1]);
				let commission = rent * (Number(this.children[2].textContent.split(' ')[1]) / 100);
				let isBudgetEnough = rent + commission <= $budget.val();

				if (isFoundApartmentType && isBudgetEnough) {
					let familyName = $familyName.val();
					profit += commission * 2;
					$('#roof h1').text(`Agency profit: ${profit} lv.`);
					$('#message').text('Enjoy your new home! :))');

					$(this).children('p:nth-child(1)').text(`${familyName}`);
					$(this).children('p:nth-child(2)').text('live here now');

					let $button = $('<button>').text('MoveOut').on('click', () =>{
						$(this).remove();
						$('#message').text(`They had found cockroaches in ${familyName}\'s apartment`);
					});

					$(this).children('p:nth-child(3)').replaceWith($button);
					$(this).css('border', '2px solid red');
					
				} else{
					$('#message').text('We were unable to find you a home, so sorry :(');
				}
			})
		}	
		
		resetFields($budget, $searchedApartment, $familyName);
	}
}