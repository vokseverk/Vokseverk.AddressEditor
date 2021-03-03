angular.module("umbraco").controller("AddressEditorPrevalueController", function ($scope) {
	if (!$scope.model.value) {
		$scope.model.value = {
			name: true,
			address: true,
			address2: false,
			zipcode: true,
			city: true,
			country: false
		}
	}
});
