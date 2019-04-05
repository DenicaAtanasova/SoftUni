$(() => {
    renderMonkeyTemplate();

    async function renderMonkeyTemplate() {
        let monkeysTemplate = await $.get('./monkeysTemplate.html');

        let compiledTemplate = Handlebars.compile(monkeysTemplate);

        let context = {
            monkeys
        };

        $('.monkeys').html(compiledTemplate(context));
    }
})

function showInfo(id){
    $(`#${id}`).toggle();
}