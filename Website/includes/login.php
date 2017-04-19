<?php
//Script is ONLY to be used for a direct login through the application
include_once 'dbconnect.php';
include_once 'functions.php';

$secretKey = "1Lnt2ZSTS6Mdc3vrysav";
 
if (isset($_REQUEST['Email'], $_REQUEST['Password'])) {
    $email = $_REQUEST['Email'];
    $password = hash('sha512', $_REQUEST['Password']); // The hashed password.
 
    if (login($email, $password, $mysqli) == true) {
        // Login success 
            $sql = "";
             if ($stmt = $mysqli->prepare("SELECT  a.username, u.money, u.highscore, u.PointsIncrease, u.Invincibility, u.DoubleJump, u.Barracades, u.Magnet
                FROM accounts a JOIN uses u ON u.email = a.email WHERE a.email =  ?
                LIMIT 1")) {
                $stmt->bind_param('s', $email);  // Bind "$email" to parameter.
                $stmt->execute();    // Execute the prepared query.
                $stmt->store_result();
         
                // get variables from result.
                $stmt->bind_result($username, $money, $highscore, $pointsIncrease, $invincibility, $doubleJump, $barracades, $magnet);
                $stmt->fetch();
            }
                echo md5($email . $secretKey);
                echo ":";
                echo md5("Success" . $secretKey);
                echo ":";
                echo $money;
                echo ":";
                echo intval($highscore);
                echo ":";
                echo $username;
                echo ":";
                echo $pointsIncrease;
                echo ":";
                echo $invincibility;
                echo ":";
                echo $doubleJump;
                echo ":";
                echo $barracades;
                echo ":";
                echo $magnet;
    } else {
            echo "Login";
            echo ":";
            echo "Failed";
            echo ":";
            echo "Login";
            echo ":";
            echo "Failed";
            echo ":";
            echo "Login";
            echo ":";
            echo "Failed";
    }
} else {
    // The correct POST variables were not sent to this page. 
    echo "Invalid";
    echo ":";
    echo "Request";
    echo ":";
    echo "Invalid";
    echo ":";
    echo "Request";
    echo ":";
    echo "Invalid";
    echo ":";
    echo "Request";
}