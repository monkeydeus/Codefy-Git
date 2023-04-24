# Git
## What is Git
### A Database
### A Version Control System
### A Collaboration Framework


## Git Setup
### Install
### Configure
- user name, email at minimum
```c
git config --global user.name "< user name>"
git config --global user.email "< user email>"
```
#### Alias

## Git Tooling
### Git/OS
#### CLI
##### posh-git
#### CMD

### Coding
#### VS Code
#### GitLens
#### Webstorm

### Gitting
#### Tower Git
#### GitHub Desktop
#### Git Kraken
#### SourceTree
#### Tortoise Git for Windows

### Comparing
#### Beyond Compare
#### VS Code
#### KDiff3
#### P4Merge
#### WinMerge

## Git Internals

### The Working Directory
### The Staging Area (Index)
### The Repository
#### The Database
#### Database Objects
##### Blobs
##### Trees
##### Commits
```c
$git cat-file < hash >
$cat < filename >
```

Different trees can reference the same objects:
![[Pasted image 20230414152321.png]]
![[Pasted image 20230414152240.png]]


### The Stash

## Using Git
### What is a commit?
A commit is a snapshot of the current state of a Git repository. It includes a set of changes to the repository's files that you've made since the last commit, along with a commit message describing the changes. Commits allow you to keep track of changes to your code over time
### What is a branch?
A branch is a separate line of development in a Git repository. It's essentially a copy of the codebase at a certain point in time, and you can make changes to it without affecting the main codebase. This allows you to experiment with new features or make changes without worrying about breaking the existing code. Braches are made up of commits, and you can see the entire history of a single branch by checking its commit history
### What is the HEAD?
The HEAD is a reference to the current commit in a branch. It's essentially a pointer that tells Git which commit you're currently working on. When you make changes to your code, the HEAD is updated to point to the new commit that includes those changes

### Creating a Repo
A GitHub repo, or repository, is a location where code and other files associated with a project are stored and managed using Git version control.
#### Init
In order to designate a directory on your local machine as a git repository you run the command:
```c
git init
```
This initializes the Git repository in by creating a .git directory with subdirectories and files that are used by git to manage the directory as a Git repository.

Once a Git repository is initialized with git init, you can use other Git commands to manage your code. Note this only initializes a repository locally, you still need to publish the repository to github in order to view and share your code to others.
#### Clone

In order to access a remote repository you will use git clone. This is used to create a copy of a remote Git repository on your local machine. The cloned repository is an exact copy of the remote repository, including all branches, tags, and commit history. You can usually find the clone url by visiting the Github page of the repo you are trying to clone.

```c
git clone https://github.com/username/repository.git
```

### Adding content to the Repo
Once we have created a local or remote repository and have it downloaded on our machine we can now start to interact with the source control features to manage our code.
#### Add
git add is a Git command used to add changes made to the files in a local repository to the staging area. The staging area is a temporary storage area where Git keeps track of changes before committing them to the repository.

Here are some common uses of the git add command:

```c
git add .
```
Adds all changes in the current directory and its subdirectories to the staging area.

```c
git add <filename>
```
Adds changes to a specific file to the staging area.

```c
git add -p
```
Allows you to interactively add changes to the staging area.

#### Commit
A command that saves changes made to the files in a local Git repository. It creates a permanent record of the changes made since the last commit, including the files that were changed, the contents of those files, and a commit message that describes the changes made.

A Git commit is typically used after making changes to the files in a local repository and adding those changes to the staging area using the git add command. Once the changes are staged, you can use the git commit command to permanently save them to the repository. 
```c
git commit -m "commit message"
```
The -m option is used to specify a commit message, which should briefly describe the changes made in the commit. Some projects will have particular requirements around the formatting of the message and can even use tools that block commits unless the message follows the desired format.

After executing the commit command a unique identifier called a hash will be created. This can be used to refer to the commit in the future.
### Viewing The Repo
There are several commands that you can run to give you more information about the state of your repository. 
#### Status
See which changes are staged and which ones are not.
```c
git status
```

#### show
displays information about a specific Git object, such as a commit, tag, or tree. It allows you to see the details of a specific object, including the changes made, the author and committer information, and the commit message.
```c
git show <object>
```
#### diff
Shows the differences between two versions of a file or between two branches. It allows you to see the changes made to a file, including which lines were added, deleted, or modified.
```c
git diff <commit> <commit>
```
#### log
Display a chronological list of commits in a repository. It shows the commit history of a branch, along with the author and committer information, the commit message, and the hash of each commit.
```c
git log
```

### Moving within the Repo
You will need to know how to navigate between branches in order to succesfully contribute your code
#### branch
Used to manage the branches in your local repository

The command on its own will list the branches in your local repository
```c
git branch
```

The command will create a new branch in your local with the provided name
```c
git branch <name>
```

Available options:
```c
-a: Lists all local and remote branches.
-d <branch name>: Deletes the specified branch. Use -D instead to force delete the branch even if it has unmerged changes.
-m <old name> <new name>: Renames the specified branch.
-r: Lists all remote branches.
-v: Lists all branches with the last commit message for each.
```
#### checkout
You can use the checkout command if you want to actually switch over to a branch commit or file in your local repository. 
```c
git checkout <branch-name>
```

Available options:
```c
-f: Forces Git to switch branches even if there are uncommitted changes in the current branch that would be overwritten.
-b <new-branch-name>: Creates a new branch and switches to it.
```
#### switch
Similar to the checkout command where it will let you switch to another branch. This is the safer and preferred method of switching branches as its a more specific command you can use when switching branches.
```c
 git switch <branch name>
```

Available Options:
```c
-c <new-branch-name> or --create <new branch name>: Creates a new branch with the specified name and switches to it.
-f or --force: Forces Git to switch branches even if there are uncommitted changes in the current branch that would be overwritten.
-d <branch-name> or --delete <branch name>: Deletes the specified branch.
```
#### tag
A tag is a label or bookmark that is associated with a specific commit in a repository. Tags are typically used to mark significant milestones, releases, or versions of a project, and they provide a way to easily reference a specific commit in the future.

Create a tag for a specific commit
```c
git tag <tag-name> <commit-hash>
```

Delete a tag
```c
git tag myTag -d
```
### Modifying the Repo
Once you code is dev complete it is time to push your changes back into the main branch
#### Merge
Merge is a command that is used to combine changes from one branch into another. It is one of the core features of Git that enables collaboration among developers working on the same project.

As an example, lets say we have a feature-branch branch that we want to merge back into our main branch.
1. Create your new branch
```c
git branch feature-branch
```
2. Switch to your new branch
```c
git switch feature-branch
```
3. Once your code is dev complete begin merge process back into main. Start with switching to main branch
```c
git checkout main
```
4. Merge the changes from your feature branch into the main branch
```c
git merge feature-branch
```

This command will take all of the changes in your feature-branch into the main branch and create a merge commit

#### Conflicts
Sometimes when you are merging code you will have conflicts between two of the same files. This occurrs when two contributors make changes to the same part of the same file, git will give you conflict markers and will allow you to decide which of the changes to include.
#### Rebase
The rebase command is used to reapply changes from one branch onto another. Unlike git merge, which creates a new merge commit, git rebase applies changes from one branch directly on top of another branch's history, resulting in a linear project history. This changes the history of the branch you are rebasing into, which can make the history difficult to trace. It is not recommended to rebase often in a project
### Fixing the Repo
Sometimes we run commands and make changes to our repo that we do not intend to make. Here are a few options to undo the changes that have been made.
#### amend commit
This will make changes to the most recent commit in your repository. This can be useful if you notice a mistake or typo in your commit message or if you need to add or remove files from the commit. You are essentially replacing the old commit with your latest updates. This can cause issues if you have multiple contributors working off of a commit that you plan to ammend.

To ammend a commit
```c
git commit --amend
```
#### Revert
When you use revert, it creates a new commit that contains the opposite changes to the original commit. For example, if the original commit added a line of code, the revert commit would remove that line of code. This is useful when you need to undo a previous commit without completely removing it from the repository history.

To revert a commit
```c
git rever <commit-hash>
```
#### Reset
reset is a command used to remove commits from the current branch and reset the current branch to a specific commit. This can be useful if you want to undo changes or start over from a specific point in the repository history.

Remove the commits from the current branch but leave the changes in the staging area. This means that you can use git commit to create a new commit with the same changes.
```c
git reset --soft:
```

This is the default and will remove the commits from the current branch and also remove the changes from the staging area. This means that you will need to use git add to stage the changes again before creating a new commit.
```c
git reset --mixed:
```

This will remove the commits from the current branch, remove the changes from the staging area, and also modify the files in your working directory to match the specified commit. This means that any changes you made since the specified commit will be lost.
```c
git reset --hard: 
```
#### Reflog

### Sharing the Repo
#### push

## Git Best Practices
### Finding a Workflow
#### Gitflow
#### Monolithic/Trunk

### Being a good citizen
#### Commit size
#### Commit messages

### Squash into Dev, Merge into Main

# Further Learning
[Tower Git](http://www.git-tower.com/learn)
[Git SCM](https://www.git-scm.com/)
[Roger Dudler](http://rogerdudler.github.io/git-guide/)