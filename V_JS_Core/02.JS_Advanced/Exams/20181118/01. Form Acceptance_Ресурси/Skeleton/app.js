function acceptance() {
	let $companyElement = $('#fields').find('input[name=shippingCompany]');
	let $productElement = $('#fields').find('input[name=productName]');
	let $quantityElement = $('#fields').find('input[name=productQuantity]');
	let $srapeElement = $('#fields').find('input[name=productScrape]');

	if (validateFields()) {
		let availableQuantity = $quantityElement.val() - $srapeElement.val();

		if (availableQuantity > 0) {
			let $div = $('<div>');
		let $p = $('<p>').text(`[${$companyElement.val()}] ${$productElement.val()} - ${availableQuantity} pieces`);
		let $btn = $('<button>Out of stock</button>').on('click', () => $div.remove());

		$div.append($p)
			.append($btn)
			.appendTo('#warehouse');

		resetFields();
		}
	}
	
	function validateFields(){
		if($companyElement.val().length < 1 || $productElement.val().length < 1 ||
		   $quantityElement.val().length < 1 || $srapeElement.val().length < 1){		
			return false;
		}

		if (isNaN($quantityElement.val()) || isNaN($srapeElement.val())) {
			return false;
		}

		return true;
	}

	function resetFields(){
		$companyElement.val('');
		$productElement.val('');
		$quantityElement.val('');
		$srapeElement.val('');
	}
}