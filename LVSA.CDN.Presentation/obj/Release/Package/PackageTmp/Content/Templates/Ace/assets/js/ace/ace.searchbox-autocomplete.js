/**
The autocomplete dropdown when typing inside search box.
<u><i class="glyphicon glyphicon-flash"></i> You don't need this. Used for demo only</u>
*/
(function($ , undefined) {

	ace.vars['_Pesquisa'] = ["Cadastrar'", "Visualizar"]
	try {
		$('#nav-search-input').bs_typeahead({
		    source: ace.vars['_Pesquisa'],
			updater:function (item) {
				//when an item is selected from dropdown menu, focus back to input element
				$('#nav-search-input').focus();
				return item;
			}
		});
	} catch(e) {}

})(window.jQuery);