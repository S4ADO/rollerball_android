<?php
include_once 'dbconnect.php';
include_once 'dbconfig.php';
 
$error_msg = "";
 
if (isset($_POST['username'], $_POST['email'], $_POST['p'])) {
    $username = filter_input(INPUT_POST, 'username', FILTER_SANITIZE_STRING);
    $email = filter_input(INPUT_POST, 'email', FILTER_SANITIZE_EMAIL);
    $email = filter_var($email, FILTER_VALIDATE_EMAIL);
    if (!filter_var($email, FILTER_VALIDATE_EMAIL)) {
        $error_msg .= '<p class="error">The email address you entered is not valid</p>';
    }
 
    $password = filter_input(INPUT_POST, 'p', FILTER_SANITIZE_STRING);
 
    $prep_stmt = "SELECT id FROM accounts WHERE email = ? LIMIT 1";
    $stmt = $mysqli->prepare($prep_stmt);
 
   // does email already exist?  
    if ($stmt) {
        $stmt->bind_param('s', $email);
        $stmt->execute();
        $stmt->store_result();
 
        if ($stmt->num_rows == 1) {
    $error_msg .= '<p class="error">A user with this email address already exists.</p>';
    $stmt->close();
} else {
    $stmt->close();
}
    } else {
       $error_msg .= '<p class="error">Database error Line 39</p>';
    }
 
    // check existing username
    $prep_stmt = "SELECT id FROM accounts WHERE username = ? LIMIT 1";
    $stmt = $mysqli->prepare($prep_stmt);
 
    if ($stmt) {
        $stmt->bind_param('s', $username);
        $stmt->execute();
        $stmt->store_result();
 
                if ($stmt->num_rows == 1) {
    echo "A user with this email address already exists";
    $stmt->close();
} else {
    $stmt->close();
}
        } else {
                $error_msg .= '<p class="error">Database error line 55</p>';
        }
 
    if (empty($error_msg)) {
        // Create a random salt
        $random_salt = hash('sha512', uniqid(mt_rand(1, mt_getrandmax()), true));
 
        // Create salted password 
        $password = hash('sha512', $password . $random_salt);
 
        // Insert the new user into the database 
        if ($insert_stmt = $mysqli->prepare("INSERT INTO accounts (username, email, password, salt) VALUES (?, ?, ?, ?)")) {
            $insert_stmt->bind_param('ssss', $username, $email, $password, $random_salt);
            // Execute the prepared query.
        }
        if ($stmt = $mysqli->prepare("INSERT INTO uses (email) VALUES (?)")) {
                $stmt->bind_param('s', $email);  // Bind "$email" to parameter.
                $stmt->execute();
        }        
    }
}