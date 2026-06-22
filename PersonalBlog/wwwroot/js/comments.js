

// load comments
async function loadComments(slug) {
    const res = await fetch(`/api/comments?slug=${slug}`);
    const comments = await res.json();

    const list = document.getElementById('comment-list');
    if (comments.length == 0) {
        list.innerHTML = '<p>There is not comments</p>';
        return;
    }
    list.innerHTML = comments.map(c => `
       <div class="comments">
            <strong>${c.authorName}</strong>
            <time>${c.CreateAt}</time>
            <p>${c.content}</p>
        </div >`
    ).join('');
}

//submit comments
async function submitComment(slug) {
    const authorName = document.getElementById('comment-author').value.trim();
    const content = document.getElementById('comment-content').value.trim();
    if (!content || !author) {
        alert('Please input author name and content!');
        return;
    }
    await fetch('/api/comments', {
        method: 'Post',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ authorName, content, slug })
    });
    //clean up textarea
    document.getElementById('comment-author').value = '';
    document.getElementById('comment-content').value = '';
    await loadComments(slug);
}
