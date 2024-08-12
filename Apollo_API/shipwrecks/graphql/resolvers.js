const shipwrecks = require('../models/shipwrecks');

module.exports = {
    Query: {
            async shipwreck(_,{ID}) {
                return await shipwrecks.findById(ID)
            },
            async shipwrecks() {
                return await shipwrecks.find()
            },
        }
    }