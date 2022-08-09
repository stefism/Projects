<template>
  <div class="create-post">
    <BlogCoverPreview v-show="this.$store.state.blogPhotoPreview" />
    <Loading v-show="loading" />
    <div class="container">
        <div :class="{ invisible: !error}" class="err-message">
            <p><span>Error:</span>{{ errorMsg }}</p>
        </div>
        <div class="blog-info">
            <input type="text" placeholder="Въведете заглавие" v-model="blogTitle">
            <div class="upload-file">
                <label for="blog-photo">Качете снимка за корица на блога</label>
                <input 
                    type="file" 
                    ref="blogPhoto" 
                    id="blog-photo"
                    @change="fileChange"
                    accept=".png, .jpg, .jpeg"
                >
                <button @click="openPreview" class="preview" :class="{ 'button-inactive': !this.$store.state.blogPhotoFileURL }">Превю на снимката</button>
                <span>Избран файл: {{ this.$store.state.blogPhotoName }}</span>
            </div>
        </div>
        <div class="editor">
            <vue-editor 
                
            />
            
            <quill-editor 
                :options="editorSettings" 
                v-model="blogHTML" 
                useCustomImageHandler
            />
        </div>
        <div class="blog-actions">
            <button @click="uploadBlog">Публикувай</button>
            <router-link class="router-button" :to="{ name: 'BlogPreview'}">Превю на поста</router-link>
        </div>
    </div>
  </div>
</template>

<script>
import BlogCoverPreview from '../components/BlogCoverPreview-comp.vue';
import Loading from '../components/Loading-comp.vue';

import firebase from 'firebase/app';
import db from '../firebase/firebaseInit.js';
import 'firebase/storage';

import { VueEditor } from "vue2-editor";
import { quillEditor } from 'vue-quill-editor'

import Quill from 'quill';
window.Quill = Quill;
const ImageResize = require('quill-image-resize-module').default;
Quill.register('modules/imageResize', ImageResize);

export default {
    name: 'CreatePost',
    components: { VueEditor, quillEditor, BlogCoverPreview, Loading },
    data() {
        return {
            file: null,
            error: null,
            errorMsg: null,
            loading: null,
            editorSettings: {
                modules: {
                    imageResize: {},
                    toolbar: [["bold","italic","underline","strike"],["blockquote","code-block"],[{"header":1},{"header":2}],[{"list":"ordered"},{"list":"bullet"}],[{"script":"sub"},{"script":"super"}],[{"indent":"-1"},{"indent":"+1"}],[{"direction":"rtl"}],[{"size":["small",false,"large","huge"]}],[{"header":[1,2,3,4,5,6,false]}],[{"color":[]},{"background":[]}],[{"font":[]}],[{"align":[]}],["clean"],["link","image","video"]]
                }
            }
        }
    },
    methods: {
        fileChange() {
            this.file = this.$refs.blogPhoto.files[0];
            this.$store.commit('fileNameChange', this.file.name);
            this.$store.commit('createFileURL', URL.createObjectURL(this.file));
        },
        openPreview(){
            this.$store.commit('openPhotoPreview');
        },
        uploadBlog() {
            if(this.blogTitle.length == 0 || this.blogHTML.length == 0) {
                this.setErrorMessage('Не сте попълнили нищо в заглавието и/или в тялото на поста.', 4000);
            } else if(!this.file) {
                this.setErrorMessage('Не сте прикачили файл за корица на поста.', 4000);
            } else {
                this.error = false;
                this.loading = true;

                const storageRef = firebase.storage().ref();
                const docRef = storageRef.child(`documents/BlogCoverPhotos/${this.$store.state.blogPhotoName}`);
                docRef.put(this.file).on(
                    'state_changed',
                    (snapshot) => {
                        console.log(snapshot);
                    },
                    (err) => {
                        console.log(err);
                        this.loading = false;
                    }, async () => {
                        const downloadURL = await docRef.getDownloadURL();
                        const timestamp = await Date.now();
                        const dataBase = await db.collection('blogPosts').doc();

                        await dataBase.set({
                            blogId: dataBase.id,
                            blogHTML: this.blogHTML,
                            blogCoverPhoto: downloadURL,
                            blogCoverPhotoName: this.blogCoverPhotoName,
                            blogTitle: this.blogTitle,
                            profileId: this.profileId,
                            date: timestamp
                        });

                        await this.$store.dispatch('getPost');
                        this.loading = false;
                        this.$router.push({ name: 'ViewBlog', params: { blogid: dataBase.id }});
                    }
                );
            }
        },
        setErrorMessage(message, stayInterval) {
            this.error = true;
            this.errorMsg = message;
            setTimeout(() => {
                    this.error = false;
                }, stayInterval);
        }
    },
    computed: {
        profileId() {
            return this.$store.state.profileId;
        },
        blogCoverPhotoName() {
            return this.$store.state.blogPhotoName;
        },
        blogTitle: {
            get() {
                return this.$store.state.blogTitle;
            },
            set(payload) {
                this.$store.commit('updateBlogTitle', payload);
            }
        },
        blogHTML: {
            get() {
                return this.$store.state.blogHTML;
            },
            set(payload) {
                this.$store.commit('newBlogPost', payload);
            }
        }
    }
}
</script>

<style lang="scss">
    .create-post {
        position: relative;
        height: 100%;

        button {
            margin-top: 0;
        }

        .router-button {
            text-decoration: none;
            color: #fff;
        }

        label,
        button,
        .router-button {
            transition: 500ms ease-in-out all;
            align-self: center;
            font-size: 14px;
            cursor: pointer;
            border-radius: 20px;
            padding: 12px 24px;
            color: #fff;
            background-color: #303030;
            text-decoration: none;

            &:hover {
                background-color: rgba(48, 48, 48, 0.7);
            }
        }

        .container {
            position: relative;
            height: 100%;
            padding: 10px 25px 60px;
        }

        .invisible {
            opacity: 0 !important;
        }

        .err-message {
            width: 100%;
            padding: 12px;
            border-radius: 8px;
            color: #fff;
            margin-bottom: 10px;
            background-color: #303030;
            opacity: 1;
            transition: 0.5s ease all;

            p {
                font-size: 14px;
            }

            span {
                font-weight: 600;
            }
        }

        .blog-info {
            display: flex;
            margin-bottom: 32px;

            input:nth-child(1) {
                min-width: 300px;
            }

            input {
                transition: 0.5s ease-in-out all;
                padding: 10px 4px;
                border: none;
                border-bottom: 1px solid #303030;

                &:focus {
                    outline: none;
                    box-shadow: 0 1px 0 0 #303030;
                }
            }

            .upload-file {
                flex: 1;
                margin-left: 16px;
                position: relative;
                display: flex;

                input {
                    display: none;
                }

                .preview {
                    margin-left: 16px;
                    text-transform: initial;
                }

                span {
                    font-size: 12px;
                    margin-left: 16px;
                    align-self: center;
                }
            }
        }

        .editor {
            height: 60vh;
            display: flex;
            flex-direction: column;

            .quill-editor {
                position: relative;
                display: flex;
                flex-direction: column;
                height: 100%;
            }

            .ql-container {
                display: flex;
                flex-direction: column;
                height: 100%;
                overflow: scroll;
            }

            .ql-editor {
                padding: 20px 16px 30px;
            }
        }

        .blog-actions {
            margin-top: 32px;

            button {
                margin-right: 16px;
            }
        }
    }
</style>