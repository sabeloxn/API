const listingsandreviews = require('../models/listingsAndReviews');

module.exports = {
    Query: {
            async listingAndReview(_,{ID}) {
                return await listingsandreviews.findById(ID)
            },
            async listingsAndReviews() {
                return await listingsandreviews.find()
            },
        }
    }