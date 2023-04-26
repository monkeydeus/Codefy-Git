# Git

## What is Git

Git is a free and open-source distributed version control system (VCS) used for software development and other version control tasks.

With Git, you can track changes made to your code over time, and collaborate with other developers as you wish. 

When Git was created, what set it apart from other version control systems was how easy it was to create entirely new versions of files and file trees.  This made experimentation and iteration simple and rapid, and allowed isolation of changes from the main codebase until the developer was sure it was ready to be integrated back.  

Git also enabled developers to work on their own version of the codebase locally, avoiding the risk of overwriting each other's changes.  
This is referred to as a distributed model, which means that every developer has their own copy of the code repository on their local machine. This allows developers to work offline and independently, while still being able to push their changes to one or more shared remote repository(ies).

When the team is ready to consolidate code to prepare for release, Git provides tools for merging versions and resolving conflicts that may arise when multiple developers make changes to the same file.

### A Database
Git creates its own version of a file structure in a collection called a repository.  Via the repository, Git stores the entire history of your project, including every change made to every file, in a series of snapshots called commits. 

A commit represents the current state of the file structure by referencing it's parent, and a *tree* , along with other metadata like the author of the commit and the commit message.  Since every commit references at least one parent, a chain of changes is established, and this is how git can move between different versions of the repository and maintain continuity.  

This is why Git is fundamentally a database.  By maintaining a record of the relationships between files, and changes to those files, Git can recreate the repository from any state that was committed to it over time.

### A Version Control System
A version control system allows you to save *multiple* versions of a file, or a file tree. Git is widely used in software development and other version control tasks. By allowing you to track changes, create branches, merge changes, and revert to earlier versions, Git helps you keep your code organized and under control.  This is a powerful way to manage your work, whether you are working alone or with a team. 

### A Collaboration Framework
Git makes it easy to collaborate with other developers by providing tools for sharing code and resolving conflicts that may arise when multiple developers are working with the same set of files.  Once you've made changes in a local repository, you and your team can choose to merge those changes back into the main codebase when you're ready.

## Git Setup

### Install

On a Mac just type in git into the terminal and it has a built in process to automatically download and setup git for you.

On Windows you can download the package directly from this url: https://git-scm.com/download/win

### Configure
Git uses multiple config files to define the environmental variables it requires to function.  Config files are defined for 
- System
- User
- Repository

When git is installed, a .gitconfig file is created in the Git directory specified at install.  By default on windows, this will be 

```c
C:\Program Files\Git\etc\.gitconfig
```

When a **user** config file is created, the default location on Windows wiil be
```c
C:/users/< user>/.gitconfig
```

Config files are also included in a repository to define separate configurations (such as remotes) for that particular repository.  When a new repository is created, git automatically creates a config for it.

```ad-tip
title: Config Hierarchy
Git config files are used in a hierarchy.  
- Each key from each config file (System, User, Repository) will be loaded into git
- The closest config file will win if the same key is defined in different config files 
```


To work with git, you will need to define at a minimum a user name and email. If either of these keys are not found, a commit will fail with an error message describing the missing key.

```c
git config --global user.name "< user name>"

git config --global user.email "< user email>"

```

#### Alias
```ad-todo
Add config file to documents
```
  

## Git Tooling

### Git/OS

#### CLI

##### posh-git

#### CMD

  

### Coding

#### VS Code
https://code.visualstudio.com/

#### GitLens
https://marketplace.visualstudio.com/items?itemName=eamodio.gitlens

#### Webstorm
https://www.jetbrains.com/webstorm/promo/?source=google&medium=cpc&campaign=9641686293&term=webstorm&content=523713720609&gad=1&gclid=CjwKCAjwl6OiBhA2EiwAuUwWZfOsd5swCJvia-9liNvXoi7U4mmGlu_qImf84Fxl23f-Qeaj1Q6lbxoCEP4QAvD_BwE
  

### Gitting
#### Tower Git
https://www.git-tower.com/windows

#### GitHub Desktop (free)
https://desktop.github.com/

#### Git Kraken (free)
- Same company that publishes GitLens for VSCode
https://www.gitkraken.com/

#### SourceTree (free)
https://www.sourcetreeapp.com/

#### Tortoise Git for Windows
- Shell integration
https://tortoisegit.org/

  

### Comparing
#### Beyond Compare
https://www.scootersoftware.com/

#### VS Code
https://code.visualstudio.com/

#### KDiff3 (free)
https://kdiff3.sourceforge.net/

#### P4Merge (free)
https://www.perforce.com/products/helix-core-apps/merge-diff-tool-p4merge

#### WinMerge (free)
https://winmerge.org/?lang=en
  

## Git Internals
### The Working Directory
The current files committed to the repository or WIP

### The Staging Area (Index)
The collection of files that will be added to or modified with the next commit.  Exists to to provide decoupling between working files and commits (can commit some of current changes separately from others, for better traceability/workflow)

### The Repository
Git's representation of the working directory.  Represents the total collection of files and folders that are **tracked** by git

### The Database
#### Database Objects
```sh
git count-objects -H -v //Shows top-level information about the database -H human readable, -v verbose
git cat-file --batch-all-objects --batch-check //shows ALL objects in the database
```

##### Blobs
Files in the git database.  Use git cat-file to see contents.
```ad-note
title: Files and Blobs
A "file" exists in two places in a git repository:

- Working Directory
- Repo blob

Even if a file is deleted from the Working Directory, it can be restored from the repository!
```

##### Trees
Analagous to directories.  Shows directory/file structure at time of commit

Different trees can reference the same objects:

![[Pasted image 20230414152321.png]]

![[Pasted image 20230414152240.png]]


##### Commits
- A **unique** collection of tree and blobs
- Slice-in-time capture of the state of the repository.  Contains information on parent(s) of commit, the tree associated with the commit, and **metadata**
	- author
	- commiter
	- message

```ad-question
- When would a commit have more than one parent?
- Why would there be an author AND a committer?
```


```c
$git cat-file < hash >
$cat < filename >
```
  

  ```ad-important
FILES != OBJECTS

- If a FILE is deleted, the OBJECT representing the file still exists. The TREE representing the working directory will not have references to those files though, so eventually garbage collection will delete the 'Unreferenced' objects.


- Branching from a commit that had a tree referencing the deleted files will restore the FILES to the working directory from the OBJECTS in the database
```
  
### The Stash
The stash allows you to temporarily save changes in your working directory that are not ready to be committed. This is useful if you need to switch to a different branch or work on a different task, but want to save the changes you've made so far without committing them to the repository. You can save multiple changes to your stash that can be applied to any branch you are currently working in.
  

## Using Git

### What is a commit?
-- pickup here --
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

  

#### Push

Once you have created all of the commits in your local and want to share the code with other devs you can run the push command. This will take the branch you have checked out locally and push all commits you have created until now to the branch where other devs can then checkout those commits.

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

  
  

#### Rebase

The rebase command is used to reapply changes from one branch onto another. Unlike git merge, which creates a new merge commit, git rebase applies changes from one branch directly on top of another branch's history, resulting in a linear project history. This changes the history of the branch you are rebasing into, which can make the history difficult to trace. It is not recommended to rebase often in a project

### Fixing the Repo

Sometimes we run commands and make changes to our repo that we do not intend to make. Here are a few options to undo the changes that have been made.

  

#### Conflicts

Sometimes when you are merging code you will have conflicts between two of the same files. This occurrs when two contributors make changes to the same part of the same file, git will give you conflict markers and will allow you to decide which of the changes to include.

#### Amend commit

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

The Reflog is a useful tool for managing your repository and tracking the history of changes made to your code. It provides a way to recover lost commits and branches, and can help you undo changes that may have been accidentally deleted.

  

### Sharing the Repo

  

## Git Best Practices

While git is a powerful way to manage code across multiple developers it is still only a tool and needs a pattern behind it in order to be succesful in a real world environment.

  

### Finding a Workflow

The workflow that the team will operate on will depend on the team. Smaller teams can get away with smaller workflows and don't need to be bogged down by the extra steps in the heavier workflows like Gitflow. But as the team size grows the extra steps and processes will be required in order to ensure continuous high quality delivery of code.

  

You can always switch up workflows at any time. If you feel the way you are currently operating is not working there is no issue with switching over to a better fitting workflow.

  

#### Gitflow

This pattern involves creating two long-lived branches: a master branch for production-ready code, and a develop branch for ongoing development. Feature branches are created off the develop branch, and once they are complete, they are merged back into the develop branch. When the develop branch is stable, it is merged into the master branch for release.

#### Monolithic/Trunk

Trunk-based development (TBD) is a Git workflow pattern that involves working directly on the master branch, rather than using feature branches. In this workflow, developers make small, incremental changes to the codebase, committing them directly to the master branch as soon as they are complete.

  

### Being a good citizen

Part of being a good developer is working in a optimal and communicative way in git. Here are a few things to keep in mind to ensure you are working optimally within your team.

#### Commit size

Keep commits as concise as possible. Each commit should be able to stand on its own but should not be so large that the entire development of your feature gets pushed into a single commit.

  

Keep the commit history clean: Avoid making "noisy" commits that don't add value to the commit history, such as committing changes that were only made to fix typos or formatting. Instead, group related changes together into a single commit, and keep the commit history as clean and organized as possible.

  

#### Branches

Use meaningful branch names: When creating branches, use meaningful names that describe what changes are being made on the branch. This makes it easier for other developers to understand what changes are being worked on, and helps to avoid confusion when merging branches.

  

#### Conventions

Follow the team's workflow: If your team has decided to follow a particular workflow, be sure to follow it consistently. This includes using the appropriate branch names, following the commit message conventions, and using the correct commands for merging and creating branches.

  

Review and test changes thoroughly: Before pushing changes to the remote repository, review and test them thoroughly to ensure they are working as expected. This helps to avoid introducing bugs or breaking the codebase for other developers.

#### Commit messages

Use clear and descriptive commit messages: When committing changes, use a clear and descriptive commit message that explains what changes were made and why they were made. This helps other developers understand the changes and makes it easier to roll back changes if necessary.

  

### Squash into Dev, Merge into Main

Another way to keep the commit history clean is to squash into dev and merge into main. When you squash a merge you are taking all of the commits in a single branch and merging them as one commit in the history. The result is a single atomic commit that gives you a clear when looking back at your main shared branches while allowing for the smaller more descriptive commits to exist with the feature branch.

  

# Further Learning

[Tower Git](http://www.git-tower.com/learn)

[Git SCM](https://www.git-scm.com/)

[Roger Dudler](http://rogerdudler.github.io/git-guide/)