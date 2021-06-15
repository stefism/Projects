import './Main.css';
import Post from '../Post/Post'

const Main = (props) => {
    return (
        <main className="main-container">
        <h1>Some Headind</h1>

        <div className="posts">
            {props.posts.map(post =>
                <Post 
                    key={post.id.toString()} 
                    content={post.content}
                    author={post.author}
                />
                    
                
        )}
        </div>
        
        </main>
    );
}

export default Main;