"use strict";

function dynAddRow($tableSelector) {
    //alert("add-row click3");

    this.parentTable = $tableSelector;
    this.tempate = $(this.parentTable).data('template');
    var count = $(this.parentTable).data('value1');
    // alert(this.tempate);
    this.evt = this.parentTable + '.add-row';

    this.addRow = function (e) {
        // alert("add-row click");

        if (e) { e.preventDefault(); }
        var $temp = $('#' + self.tempate).val();
        if ($temp == undefined) { return; }
        var totalRow = $(self.parentTable + ' tbody tr').length;
        $temp = $temp.replace(/{i}/g, totalRow);
        $temp = $temp.replace(/{v}/g, count);


        var $table = $(self.parentTable + ' tbody').append('<tr>' + $temp + '</tr>');

        applySelect();

        //focus on first input
        console.log($(self.parentTable + ' tbody tr:last-child').find('.search-select').eq(0));
        $(self.parentTable + ' tbody tr:last-child').find('.search-select').eq(0).focus();


    };
    this.removeRow = function (e) {
        if (e) { e.preventDefault(); }
        $(this).closest("tr").remove(); // remove row
        return false;
    };


    var self = this;

    $(document).on('click', self.parentTable + " .add-row", self.addRow);
    $(document).on('click', self.parentTable + ' .remove-row', self.removeRow);

}




"use strict";

function dynAddRow1($tableSelector) {
    this.parentTable = $tableSelector;
    this.tempate = $(this.parentTable).data('template');

    this.evt = this.parentTable + '.add-row1';
    this.addRow = function (e) {
        // alert("add-row click");

        if (e) { e.preventDefault(); }
        var $temp = $('#' + self.tempate).val();
        if ($temp == undefined) { return; }
        var totalRow = $(self.parentTable + ' tbody tr').length;
        $temp = $temp.replace(/{i}/g, totalRow);
        var $table = $(self.parentTable + ' tbody').append('<tr>' + $temp + '</tr>');

        applySelect();

        //focus on first input
        console.log($(self.parentTable + ' tbody tr:last-child').find('.search-select').eq(0));
        $(self.parentTable + ' tbody tr:last-child').find('.search-select').eq(0).focus();


    };
    this.removeRow = function (e) {
        if (e) { e.preventDefault(); }
        $(this).closest("tr").remove(); // remove row
        return false;
    };


    var self = this;

    $(document).on('click', self.parentTable + " .add-row1", self.addRow);
    $(document).on('click', self.parentTable + ' .remove-row1', self.removeRow);

}

"use strict";

function dynAddRow2($tableSelector) {
    this.parentTable = $tableSelector;
    this.tempate = $(this.parentTable).data('template');

    this.evt = this.parentTable + '.add-row2';
    this.addRow = function (e) {
        // alert("add-row click");

        if (e) { e.preventDefault(); }
        var $temp = $('#' + self.tempate).val();
        if ($temp == undefined) { return; }
        var totalRow = $(self.parentTable + ' tbody tr').length;
        $temp = $temp.replace(/{i}/g, totalRow);
        var $table = $(self.parentTable + ' tbody').append('<tr>' + $temp + '</tr>');

        applySelect();

        //focus on first input
        console.log($(self.parentTable + ' tbody tr:last-child').find('.search-select').eq(0));
        $(self.parentTable + ' tbody tr:last-child').find('.search-select').eq(0).focus();


    };
    this.removeRow = function (e) {
        if (e) { e.preventDefault(); }
        $(this).closest("tr").remove(); // remove row
        return false;
    };


    var self = this;

    $(document).on('click', self.parentTable + " .add-row2", self.addRow);
    $(document).on('click', self.parentTable + ' .remove-row2', self.removeRow);

}

"use strict";

function dynAddRowBuild($tableSelector) {
    this.parentTable = $tableSelector;
    this.tempate = $(this.parentTable).data('template');

    this.evt = this.parentTable + '.build_add-row';
    this.addRow = function (e) {
        // alert("add-row click");

        if (e) { e.preventDefault(); }
        var $temp = $('#' + self.tempate).val();
        if ($temp == undefined) { return; }
        var totalRow = $(self.parentTable + ' tbody tr').length;
        $temp = $temp.replace(/{i}/g, totalRow);
        var $table = $(self.parentTable + ' tbody').append('<tr>' + $temp + '</tr>');

        applySelect();

        //focus on first input
        console.log($(self.parentTable + ' tbody tr:last-child').find('.search-select').eq(0));
        $(self.parentTable + ' tbody tr:last-child').find('.search-select').eq(0).focus();


    };
    this.removeRow = function (e) {
        if (e) { e.preventDefault(); }
        $(this).closest("tr").remove(); // remove row
        return false;
    };


    var self = this;

    $(document).on('click', self.parentTable + " .build_add-row", self.addRow);
    $(document).on('click', self.parentTable + ' .build_remove-row', self.removeRow);

}
// Handler for .ready() called.

"use strict";

function dynAddRowWaiv($tableSelector) {
    //alert("add-row click3");

    this.parentTable = $tableSelector;
    this.tempate = $(this.parentTable).data('template');
    // alert(this.tempate);
    this.evt = this.parentTable + '.add-row-waiv';

    this.addRow = function (e) {
        // alert("add-row click");

        if (e) { e.preventDefault(); }
        var $temp = $('#' + self.tempate).val();
        if ($temp == undefined) { return; }
        var totalRow = $(self.parentTable + ' tbody tr').length;
        $temp = $temp.replace(/{i}/g, totalRow);


        var $table = $(self.parentTable + ' tbody').append('<tr>' + $temp + '</tr>');

        applySelect();

        //focus on first input
        console.log($(self.parentTable + ' tbody tr:last-child').find('.search-select').eq(0));
        $(self.parentTable + ' tbody tr:last-child').find('.search-select').eq(0).focus();


    };
    this.removeRow = function (e) {
        if (e) { e.preventDefault(); }
        $(this).closest("tr").remove(); // remove row
        return false;
    };


    var self = this;

    $(document).on('click', self.parentTable + " .add-row-waiv", self.addRow);
    $(document).on('click', self.parentTable + ' .remove-row-waiv', self.removeRow);

}

// Handler for .ready() called.
"use strict";

function dynAddRowHour($tableSelector) {
    //alert("add-row click3");

    this.parentTable = $tableSelector;
    this.tempate = $(this.parentTable).data('template');
    // alert(this.tempate);
    this.evt = this.parentTable + '.add-row';

    this.addRow = function (e) {
        // alert("add-row click");

        if (e) { e.preventDefault(); }
        var $temp = $('#' + self.tempate).val();
        if ($temp == undefined) { return; }
        var totalRow = $(self.parentTable + ' tbody tr').length;
        $temp = $temp.replace(/{i}/g, totalRow);


        var $table = $(self.parentTable + ' tbody').append('<tr>' + $temp + '</tr>');
        $("[data-toggle='toggle']").bootstrapToggle('destroy')
        $("[data-toggle='toggle']").bootstrapToggle();
        applySelect();

        //focus on first input
        console.log($(self.parentTable + ' tbody tr:last-child').find('.search-select').eq(0));
        $(self.parentTable + ' tbody tr:last-child').find('.search-select').eq(0).focus();


    };
    this.removeRow = function (e) {
        if (e) { e.preventDefault(); }
        $(this).closest("tr").remove(); // remove row
        return false;
    };


    var self = this;

    $(document).on('click', self.parentTable + " .add-row", self.addRow);
    $(document).on('click', self.parentTable + ' .remove-row', self.removeRow);

}

function dynAddRowCategory($tableSelector) {
    //alert("add-row click3");

    this.parentTable = $tableSelector;
    this.tempate = $(this.parentTable).data('template');

    // alert(this.tempate);
    this.evt = this.parentTable + '.add-table';

    this.addTable = function (e) {
        // alert("add-row click");

        if (e) { e.preventDefault(); }
        var $temp = $('#' + self.tempate).val();
        if ($temp == undefined) { return; }
        var totalRow = $(self.parentTable + ' table').length;
        $temp = $temp.replace(/{p}/g, totalRow + 1);
        $temp = $temp.replace(/_randID/g, totalRow);

        var $table = $(self.parentTable).append('<table>' + $temp + '</table>');

        applySelect();

        //focus on first input
        //console.log($(self.parentTable + ' tbody tr:last-child').find('.search-select').eq(0));
        //$(self.parentTable + ' table:last-child').find('.search-select').eq(0).focus();


    };
    this.removeTable = function (e) {
        if (e) { e.preventDefault(); }
        $(this).closest("table").remove(); // remove row
        return false;
    };


    var self = this;

    $(document).on('click', self.parentTable + " .add-table", self.addTable);
    $(document).on('click', self.parentTable + ' .remove-table', self.removeTable);

}



function dynAddDiv($tableSelector) {
    this.parentTable = $tableSelector;
    this.tempate = $(this.parentTable).data('template');
    // alert(this.tempate);
    this.evt = this.parentTable + '.add-div';

    this.addDiv = function (e) {
        //alert("add-row click");

        if (e) { e.preventDefault(); }
        var $temp = $('#' + self.tempate).html();
        if ($temp == undefined) { return; }
        var totalRow = $(self.parentTable + ' table').length;
        $temp = $temp.replace(/{i}/g, totalRow + 1);
        $temp = $temp.replace(/{p}/g, totalRow + 1);
        $temp = $temp.replace(/_randID/g, totalRow);

        var $table = $(self.parentTable).append($temp);

        applySelect();
    };
    this.removeDiv = function (e) {
        if (e) { e.preventDefault(); }
        $(this).closest("table").remove(); // remove row
        return false;
    };


    var self = this;

    $(document).on('click', self.parentTable + " .add-div", self.addDiv);
    $(document).on('click', self.parentTable + ' .remove-div', self.removeDiv);

}