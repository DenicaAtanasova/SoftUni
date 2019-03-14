function solve(selector) {
    let $target = $(selector).children();
    if ($target.length === 0) {
        $(selector).addClass('highlight');
        return;
    }

    let $nextTarget = $target;

    while($nextTarget.length){
        $target = $nextTarget;
        $nextTarget = $nextTarget.children();
    }

    $target.first().addClass('highlight');
    $target.first().parentsUntil($(selector).parent()).addClass('highlight');
}