<?php

declare(strict_types = 1);

/**
 * Problem:
 * Oft ändernde Klasse
 */
class PayPal
{
    public function sendPayment(int $amount)
    {
        echo 'Paying via PayPal: '. $amount;
    }
}

/**
 * Lösung:
 * Interface für jeden Adapter
 */
interface PaymentInterface
{
    public function pay(int $amount);
}

class PaypalAdapter implements PaymentInteface
{
    /**
     * @var PayPal
     */
    private $paypal;

    public function __construct(PayPal $paypal)
    {
        $this->paypal = $paypal;
    }

    public function pay(int $amount)
    {
        $this->paypal->sendPayment($amount);
    }
}
