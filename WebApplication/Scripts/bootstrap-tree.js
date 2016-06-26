$.fn.extend({
    treed: function (o) {

        var openedClass = 'glyphicon-minus-sign';
        var closedClass = 'glyphicon-plus-sign';

        if (typeof o != 'undefined') {
            if (typeof o.openedClass != 'undefined') {
                openedClass = o.openedClass;
            }
            if (typeof o.closedClass != 'undefined') {
                closedClass = o.closedClass;
            }
        };

        //initialize each of the top levels
        var tree = $(this);
        tree.addClass("tree");
        tree.find('li').has("ul").each(function () {
            var branch = $(this); //li with children ul
            branch.prepend($('<i>').addClass('indicator glyphicon').addClass(closedClass).on('click', function(e) {
                if (this == e.target) {
                    var icon = $(branch).children('i:first');
                    icon.toggleClass(openedClass + " " + closedClass);
                    $(branch).children().children().toggle();
                }
            }));
            branch.addClass('branch');
            branch.children().children().toggle();
        });
        //fire event from the dynamically added icon
        tree.find('.indicator').each(function () {
            $(this).on('click', function () {
                $(this).closest('li').click();
            });
        });

        //fire event to open branch if the li contains a button instead of text
        tree.find('.branch>button').each(function () {
            $(this).on('click', function (e) {
                $(this).closest('li').click();
                e.preventDefault();
            });
        });
    }
});