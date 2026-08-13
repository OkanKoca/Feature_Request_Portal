$(function () {
    var l = abp.localization.getResource('Feature_Request_Portal');
    var featureRequestsService = feature_Request_Portal.featureRequests.featureRequest;

    var getFilter = function () {
        return { status: $('#StatusFilter').val() || null }
    }

    var dataTable = $('#FeatureRequestsTable').DataTable(abp.libs.datatables.normalizeConfiguration({
        serverSide: true,
        paging: true,
        pageLength: 15,
        order: [],
        searching: false,
        scrollX: true,
        ajax: abp.libs.datatables.createAjax(featureRequestsService.getList, getFilter),
        columnDefs: [
            {
                title: l('Title'),
                data: "title",
                orderable: false,
                render: function (data, type, row) {
                    var url = abp.appPath + 'FeatureRequests/' + row.id;
                    return '<a href="' + url + '">' + $('<div>').text(data).html() + '</a>';
                }
            },
            {
                title: l('VoteCount'),
                data: "voteCount",
                orderable: true,
            },
            {
                title: l('Status'),
                data: "status",
                orderable: false,
                render: function (data) {
                    return l('Enum:FeatureRequestStatus.' + data);
                }
            },
            {
                title: l('CreationTime'),
                data: "creationTime",
                orderable: false,
                dataFormat: "datetime"
            }
        ]
        })
    );

    $('#StatusFilter').on('change', function () {
        dataTable.ajax.reload();
    });

});