$(function () {
    var l = abp.localization.getResource('Feature_Request_Portal');
    var featureRequestsService = feature_Request_Portal.featureRequests.featureRequest;

    $('#VoteButton').on('click', function () {
        var $button = $(this);
        var id = $button.data('id');

        featureRequestsService.vote(id).then(function (newVoteCount) {
            $('#VoteCount').text(newVoteCount);
            $button.prop('disabled', true).text(l('AlreadyVoted'));
            abp.notify.success(l('VoteRecorded'));
        });
    })

    $('#DeleteButton').on('click', function () {
        var id = $(this).data('id');

        abp.message.confirm(
            l('DeleteConfirmationMessage'),
            function (confirmed) {
                if (!confirmed) {
                    return;
                }

                featureRequestsService.delete(id).then(function () {
                    abp.notify.success(l('DeletedSuccessfully'))
                    window.location.href = abp.appPath + 'FeatureRequests';
                });
            }
        );
    });
});