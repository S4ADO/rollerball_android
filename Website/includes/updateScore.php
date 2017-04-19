<?php
include_once 'dbconnect.php';
include_once 'functions.php';

$secretKey = "1Lnt2ZSTS6Mdc3vrysav";
$email = $_REQUEST['email'];
$emailHash = $_REQUEST['verif'];
$coins = $_REQUEST['coins'];
$time =  $_REQUEST['time'];

if(md5($email . $secretKey) == $emailHash)
{
	$coins = intval($coins);
	$time = intval($time);
	if ($stmt = $mysqli->prepare("UPDATE uses SET highscore = IF($time > highscore, $time, highscore) , `money` = `money` + $coins
                        WHERE email = ?
                        LIMIT 1")) 
             {
                        $stmt->bind_param('s', $email);  // Bind "$email" to parameter.
                        $stmt->execute();    // Execute the prepared query.
                        $stmt->store_result();
             }
}
?>