import firebase from 'firebase/app';
import 'firebase/firestore';

const firebaseConfig = {
    apiKey: "AIzaSyDqUdTAHF_GO1dx2Z3wqyX1FvmeSNiK46c",
    authDomain: "fireblogsyt-fa6dd.firebaseapp.com",
    projectId: "fireblogsyt-fa6dd",
    storageBucket: "fireblogsyt-fa6dd.appspot.com",
    messagingSenderId: "605613916047",
    appId: "1:605613916047:web:4c7798518f495dae9a95fa"
};

const firebaseApp = firebase.initializeApp(firebaseConfig);
const timestamp = firebase.firestore.FieldValue.serverTimestamp;

export { timestamp };
export default firebaseApp.firestore();