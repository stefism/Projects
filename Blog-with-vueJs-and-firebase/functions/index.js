const functions = require('firebase-functions');

const admin = require('firebase-admin');
admin.initializeApp();

exports.addAdminRole = functions.https.onCall((data) => {
    return admin
    .auth()
    .getUserByEmail(data.email)
    .then((user) => {
            return admin.auth().setCustomUserClaims(user.uid, {
                admin: true,
            });
        })
        .then(() => {
            return {
                message: `Потребител с и-мейл ${data.email} е успешно добавен като администратор.`
            }
        })
        .catch((err) => {
            console.log(err);
        });
});


