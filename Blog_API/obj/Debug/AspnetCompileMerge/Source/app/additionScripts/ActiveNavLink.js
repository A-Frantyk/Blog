(function(){
    'use strict'

    $(document).on('click', '.navbar-nav li', function () {
        $(this).addClass('active').siblings().removeClass('active');
    });

})();